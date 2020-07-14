import React, { Component } from 'react';
import { Row, Col, InputGroup, FormControl, Button, Table } from 'react-bootstrap';
import { DropdownButton } from './DropdownButton';
import { withRouter } from 'react-router-dom';
import { Pagination } from './Pagination';
import { AuthService } from '../service/AuthService';

export default withRouter(class ServiceType extends Component {
    constructor(props) {
        super(props);
        this.state = {
            serviceTypes: [],
            page: {
                pageSize: 0
            },
            isLoading: false
        };
        this.searchTextInput = React.createRef();
        this.initializePageServiceTypes = this.initializePageServiceTypes.bind(this);
        this.handleClick = this.handleClick.bind(this);
        this.handleSearchServiceTypes = this.handleSearchServiceTypes.bind(this);

        if (AuthService.isAuth()) {
            const api = "api/ServiceType/GetServiceTypes";
            fetch(api, {
                headers: {
                    "content-type": "application/json",
                    "authorization": "Bearer " + AuthService.token()
                }
            }).then(response => {
                    if (response.status === 200) {
                        return response.json();
                    } else if (response.status === 401) {
                        this.props.history.push('/login');
                    }
            }).then(data => {
                this.setState({
                    serviceTypes: data
                }, () => this.initializePageServiceTypes());
            }).catch(err => console.log(err));
        } else {
            this.props.history.push('/login');
        }


    }

    initializePageServiceTypes() {
        const aPageSize = 200;    
        const aDefinedPageNumber = this.props.match.params.page;
        const items = this.state.serviceTypes;        
        const aTotalPages = Math.ceil(items.length / aPageSize);
        let aPageNumber = 1;
        let aPageItems = [];
        if (items.length > aPageSize) {
            aPageItems = items.slice(0, aPageSize);
        } else {
            aPageItems = items;
        }
        if (aDefinedPageNumber !== undefined) {
            aPageNumber = aDefinedPageNumber;
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
            const items = this.state.serviceTypes;
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

    handleSearchServiceTypes(event) {
        event.preventDefault();
        const aSearchKeyWord = String(this.searchTextInput.current.value);
        this.setState({ isLoading: false }, () => {
            if (AuthService.isAuth()) {
                fetch('api/ServiceType/SearchServiceTypes', {
                    method: 'POST',
                    body: JSON.stringify(aSearchKeyWord),
                    headers: {
                        "content-type": 'application/json',
                        "authorization": "Bearer " + AuthService.token()
                    }
                }).then(response => {
                        if (response.status === 200) {
                            return response.json();
                        } else if (response.status === 404) {
                            this.props.history.push("/login");
                        }
                }).then(data => {
                    this.setState({ serviceTypes: data }, () => this.initializePageServiceTypes());
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
                                <Button variant="outline-primary" onClick={this.handleSearchServiceTypes}>Search</Button>
                            </InputGroup.Append>
                        </InputGroup>
                    </Col>
                    <Col sm={7}>
                        <DropdownButton blinks={[{ action: "Add", text: "Add New Service Type", link: "/servicetypedetail/Add" }]} />
                    </Col>
                </Row>
                <Row>
                    <Col sm={12}>
                        <Table striped bordered hover>
                            <thead>
                                <tr>
                                    {/* <th scope="col">#</th> */}
                                    <th scope="col">Options </th>
                                    <th scope="col">ServiceTypeID</th>
                                    <th scope="col">Name</th>
                                    {/* <th scope="col">Image</th> */}                                    
                                    {/* <th scope="col">Options</th> */}
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.page.pageItems.map((servicetype, index) => {
                                        return (
                                            <tr key={servicetype.serviceTypeId}>
                                                <td>
                                                    <DropdownButton blinks={[
                                                        { link: "/servicetypedetail/view/" + this.state.page.pageNumber + "/" + servicetype.serviceTypeId, action: "view", text: "View" },
                                                        { link: "/servicetypedetail/edit/" + this.state.page.pageNumber + "/" + servicetype.serviceTypeId, action: "edit", text: "Edit" },
                                                        { link: "/servicetypedetail/delete/" + this.state.page.pageNumber+"/" + servicetype.serviceTypeId, action: "delete", text: "Delete" }
                                                    ]} />
                                                </td>
                                                {/* <th scope="row">{index}</th> */}
                                                <td>{servicetype.serviceTypeId}</td>
                                                <td>{servicetype.name}</td>
                                                {/* <td>{servicetype.image}</td> */}

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
