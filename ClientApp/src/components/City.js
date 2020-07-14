import React, { Component } from 'react';
import { Row, Col, InputGroup, FormControl, Button, Table } from 'react-bootstrap';
import { DropdownButton } from './DropdownButton';
import { withRouter } from 'react-router-dom';
import { Pagination } from './Pagination';
import { AuthService } from '../service/AuthService';

export default withRouter(class City extends Component {
    constructor(props) {
        super(props);
        this.state = {
            cities: [],
            page: {
                pageSize: 0
            },
            isLoading: false
        };
        this.searchTextInput = React.createRef();
        this.initializePageCities = this.initializePageCities.bind(this);
        this.handleClick = this.handleClick.bind(this);
        this.handleSearchCities = this.handleSearchCities.bind(this);
        this.sortTable = this.sortTable.bind(this);

        if (AuthService.isAuth()) {
            const api = "api/OntarioCity/GetCities";
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
                    cities: data
                }, () => this.initializePageCities());
            }).catch(err => console.log(err));
        } else {
            this.props.history.push('/login');
        }


    }

    initializePageCities() {
        const aPageSize = 200;    
        const aCityDefinedPageNumber = this.props.match.params.page;
        const items = this.state.cities;        
        const aTotalPages = Math.ceil(items.length / aPageSize);
        let aPageNumber = 1;
        let aPageItems = [];
        if (items.length > aPageSize) {
            aPageItems = items.slice(0, aPageSize);
        } else {
            aPageItems = items;
        }
        if (aCityDefinedPageNumber !== undefined) {
            aPageNumber = aCityDefinedPageNumber;
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
            const items = this.state.cities;
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

    handleSearchCities(event) {
        event.preventDefault();
        const aSearchKeyWord = String(this.searchTextInput.current.value);
        this.setState({ isLoading: false }, () => {
            if (AuthService.isAuth()) {
                fetch('api/OntarioCity/SearchCities', {
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
                    this.setState({ cities: data }, () => this.initializePageCities());
                }).catch(err => console.log(err));
            } else {
                this.props.history.push("/login");
            }
        });
       
        
    }

    sortTable(event) {
        event.preventDefault();
        const sortedCities = this.state.cities.sort((a,b) =>{
            let valueA = a.name.toUpperCase();
            let valueB = b.name.toUpperCase();
            if (valueA < valueB)
                return -1
            if (valueA > valueB)
                return 1
            else return 0
        })

        let imgTag = document.getElementById("nameSortIcon");

        if (imgTag.sortType == "init" || imgTag.sortType == "down"){
            imgTag.src = "https://i.ibb.co/5hTRFft/sort-up.png";
            imgTag.sortType = "up";   
            sortedCities.reverse();
        }else{
            imgTag.src = "https://i.ibb.co/Pt8qtbJ/sort-down.png";
            imgTag.sortType = "down";
        }

        this.setState({
            cities: sortedCities
        }, () => {
            this.initializePageCities();
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
                                <Button variant="outline-primary" onClick={this.handleSearchCities}>Search</Button>
                            </InputGroup.Append>
                        </InputGroup>
                    </Col>
                    <Col sm={7}>
                        <DropdownButton blinks={[{ action: "Add", text: "Add New City", link: "/citydetail/Add" }]} />
                    </Col>
                </Row>
                <Row>
                    <Col sm={12}>
                        <Table striped bordered hover>
                            <thead>
                                <tr>
                                    {/* <th scope="col">#</th> */}
                                    <th scope="col">Options </th>
                                    <th scope="col">OntarioCityID</th>
                                    <th scope="col">
                                        City Name
                                        <img src="https://i.ibb.co/zSfCgMC/Sort-both.png" 
                                                alt="sort" 
                                                height="15" width="20"
                                                onClick={(e) => this.sortTable(e)}
                                                id="nameSortIcon"
                                                sortType="init"/>                                    
                                    </th>
                                    <th scope="col">lat</th>
                                    <th scope="col">Long</th>                                    
                                    {/* <th scope="col">Options</th> */}
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.page.pageItems.map((city, index) => {
                                        return (
                                            <tr key={city.ontarioCityId}>
                                                {/* <th scope="row">{index}</th> */}
                                                <td>
                                                    <DropdownButton blinks={[
                                                        { link: "/citydetail/view/" + this.state.page.pageNumber + "/" + city.ontarioCityId, action: "view", text: "View" },
                                                        { link: "/citydetail/edit/" + this.state.page.pageNumber + "/" + city.ontarioCityId, action: "edit", text: "Edit" },
                                                        { link: "/citydetail/delete/" + this.state.page.pageNumber+"/" + city.ontarioCityId, action: "delete", text: "Delete" }
                                                    ]} />
                                                </td>
                                                <td>{city.ontarioCityId}</td>
                                                <td>{city.name}</td>
                                                <td>{city.lat}</td>
                                                <td>{city.long}</td>
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
