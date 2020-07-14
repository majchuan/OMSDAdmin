import React, { Component } from 'react';
import { Row, Col, InputGroup, FormControl, Button, Table } from 'react-bootstrap';
import { DropdownButton } from './DropdownButton';
import { withRouter } from 'react-router-dom';
import { Pagination } from './Pagination';
import { AuthService } from '../service/AuthService';

export default withRouter(class User extends Component {
    constructor(props) {
        super(props);
        this.state = {
            users: [],
            page: {
                pageSize: 0
            },
            isLoading: false
        };
        this.searchTextInput = React.createRef();
        this.initializePageUsers = this.initializePageUsers.bind(this);
        this.handleClick = this.handleClick.bind(this);
        this.handleSearchUsers = this.handleSearchUsers.bind(this);

        if (AuthService.isAuth()) {
            const api = "api/User/GetUsers";
            fetch(api, {
                headers: {
                    "content-type": "application/json",
                    "authorization": "Bearer " + AuthService.token()
                }
            }).
                then(response => {
                    if (response.status === 200) {
                        return response.json();
                    } else if (response.status === 401) {
                        this.props.history.push('/login');
                    }
                }).
                then(data => {
                    this.setState({
                        users: data
                    }, () => this.initializePageUsers());
                }).catch(err => console.log(err));
        } else {
            this.props.history.push('/login');
        }


    }

    initializePageUsers() {
        const aPageSize = 20;    
        const aUserDefinedPageNumber = this.props.match.params.page;
        const items = this.state.users;
        const aTotalPages = Math.ceil(items.length / aPageSize);
        let aPageNumber = 1;
        let aPageItems = [];
        if (items.length > aPageSize) {
            aPageItems = items.slice(0, aPageSize);
        } else {
            aPageItems = items;
        }
        if (aUserDefinedPageNumber !== undefined) {
            aPageNumber = aUserDefinedPageNumber;
        }

        this.setState({
            page: {
                pageSize: aPageSize,
                pageItems: aPageItems,
                totalPages: aTotalPages,
                pageNumber: aPageNumber
            }
        }, () => {
                this.setState({ isLoading: true });
        });
    }

    handleClick(aPage) {
        this.setState({
            isLoading: false
        }, () => {
            const items = this.state.users;
            const pageNumber = aPage.pageNumber;
            const pageSize = aPage.pageSize;
            const totalPage = aPage.totalPages;
            const startIndex = (pageNumber - 1) * pageSize;
            const endIndex = pageNumber <= totalPage ? (pageNumber * pageSize) - 1 : items.length - 1;
            const pageItem = items.slice(startIndex, endIndex);
            this.setState({
                page: {
                    pageSize: pageSize,
                    pageItems: pageItem, totalPages: totalPage, pageNumber: pageNumber
                }
            }, () => {
                    this.setState({
                        isLoading: true
                    });
            });
        });
    }

    handleSearchUsers(event) {
        event.preventDefault();
        const aSearchKeyWord = String(this.searchTextInput.current.value);
        this.setState({ isLoading: false }, () => {
            if (AuthService.isAuth()) {
                fetch('api/User/SearchUsers', {
                    method: 'POST',
                    body: JSON.stringify(aSearchKeyWord),
                    headers: {
                        "content-type": 'application/json',
                        "authorization": "Bearer " + AuthService.token()
                    }
                }).
                    then(response => {
                        if (response.status === 200) {
                            return response.json();
                        } else if (response.status === 404) {
                            this.props.history.push("/login");
                        }
                    }).
                    then(data => {
                        this.setState({ users: data }, () => this.initializePageUsers());
                    }).catch(err => console.log(err));
            } else {
                this.props.history.push("/login");
            }
        });
       
        
    }

    render() {

        if (this.state.isLoading === false ) {
            return (
                <p><em>Loading...</em></p>
            );
        }
        return (
            <div>
                <Row>
                    <Col sm={5}>
                        <InputGroup className="mb-3">
                            <FormControl placeholder="Search" aria-label="Search" aria-describedby="basic-addon1" class="mb-3" ref={this.searchTextInput} />
                            <InputGroup.Append>
                                <Button variant="outline-primary" onClick={this.handleSearchUsers}>Search</Button>
                            </InputGroup.Append>
                        </InputGroup>
                    </Col>
                    <Col sm={7}>
                        <DropdownButton blinks={[{ action: "Add", text: "Add New User", link: "/userdetail/Add" }]} />
                    </Col>
                </Row>
                <Row>
                    <Col sm={12}>
                        <Table striped bordered hover>
                            <thead>
                                <tr>
                                    {/* <th scope="col">#</th> */}
                                    <th scope="col">User Name</th>
                                    <th scope="col">Address</th>
                                    <th scope="col">Email</th>
                                    {/* <th scope="col">Password</th> */}
                                    <th scope="col">Phone Number</th>
                                    {/* <th scope="col">Options</th> */}
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.page.pageItems.map((user, index) => {
                                        return (
                                            <tr key={user.userId}>
                                                {/* <th scope="row">{index}</th> */}
                                                <td>{user.userFirstName},{user.userLastName}</td>
                                                <td>{user.address},{user.city},{user.province},{user.postCode}</td>
                                                <td>{user.email}</td>
                                                {/* <th>{user.password}</th> */}
                                                <td>{user.phoneNumber}</td>
                                                {/* <td>
                                                    <DropdownButton blinks={[
                                                        { link: "/userdetail/view/" + this.state.page.pageNumber + "/" + user.userId, action: "View", text: "View User Detail" },
                                                        { link: "/userdetail/edit/" + this.state.page.pageNumber + "/" + user.userId, action: "Edit", text: "Edit User Detail" },
                                                        { link: "/userdetail/delete/" + this.state.page.pageNumber+"/" + user.userId, action: "Delete", text: "Delete a user" }
                                                    ]} />
                                                </td> */}
                                            </tr>);
                                    })
                                }
                            </tbody>
                        </Table>
                    </Col>
                </Row>
                <Row>
                    <Col sm="12">
                        <Pagination page={this.state.page} onClick={this.handleClick} />
                    </Col>
                </Row>
            </div >
        );
    }
});
