import React, { Component } from 'react';
import { Dropdown, Row, InputGroup, FormControl, Button, Col, Table, Pagination, ListGroup, PageItem } from 'react-bootstrap';
import { DropdownButton } from './DropdownButton';
import { AuthService } from '../service/AuthService';
import { withRouter } from 'react-router-dom';
import { Form, FormGroup, ControlLabel } from "react-bootstrap";

export default withRouter(class Home extends Component {
    displayName = Home.name

    constructor(props) {
        super(props);
        this.state = {
            clinics: [], page: {}, isLoading: false
        };
        this.searchTextInput = React.createRef();
        this.handleClick = this.handleClick.bind(this);
        this.handlePaginationClick = this.handlePaginationClick.bind(this);
        this.sortTable = this.sortTable.bind(this);

        if (AuthService.isAuth() === false) {
            this.props.history.push('/login');
        }
    }

    componentDidMount() {

        fetch('api/Home/GetClinics', {
            method: "GET",
            headers: {
                "content-type": "application/json",
                "authorization": "Bearer " + AuthService.token()
            }
        })
            .then(response => {
                if (response.status === 401) {
                    AuthService.logout();
                    this.props.history.push('/login');
                } else {
                    return response.json();
                }
            })
            .then(data => {
                this.setState({
                    clinics: data
                }, () => {
                    this.initilizePagination();
                });
            }).catch(err => console.log(err));

    }

    handleClick(event) {
        event.preventDefault();
        const aSearchKeyWord = String(this.searchTextInput.current.value);
        fetch('api/Home/SearchClinics', {
            method: 'POST',
            body: JSON.stringify(aSearchKeyWord),
            headers: {
                "content-type": 'application/json',
                "authorization": "Bearer " + AuthService.token()
            }
        }).
            then(response => response.json()).
            then(data => {
                this.setState({
                    clinics: data
                }, () => {
                    this.initilizePagination();
                });
            }).catch(err => console.log(err));
    }

    initilizePagination() {
        const aPageSize = 10;
        const aPageNumber = 1;
        const aTotalPages = Math.ceil(this.state.clinics.length / aPageSize);
        const activePage = this.props.match.params.page === undefined ? aPageNumber : parseInt(this.props.match.params.page);

        let aPageClinics = [];
        if (activePage === 1) {
            if (this.state.clinics.length > aPageSize) {
                aPageClinics = this.state.clinics.slice(0, aPageSize);
            } else {
                aPageClinics = this.state.clinics.slice(0, this.state.clinics.length);
            }
            this.setState({ page: { pageSize: aPageSize, pageClinics: aPageClinics, totalPages: aTotalPages, pageNumber: activePage } }, () => {
                this.setState({
                    isLoading: true
                });
            });
        } else {
            if (this.state.clinics.length > aPageSize && this.state.clinics.length > ((activePage + 1) * aPageSize)) {
                
                aPageClinics = this.state.clinics.slice(activePage * aPageSize,  aPageSize * (activePage + 1));
            } else if (this.state.clinics.length > aPageSize &&
                this.state.clinics.length <= ((activePage + 1) * aPageSize) &&
                this.state.clinics.length > (activePage * aPageSize)) {
                aPageClinics = this.state.clinics.slice(activePage * aPageSize, this.state.clinics.length);
            } else if (this.state.clinics.length > aPageSize && this.state.clinics.length <= activePage * aPageSize) {
                aPageClinics = this.state.clinics.slice((activePage - 1) * aPageSize, this.state.clinics.length);
            } else if (this.state.clinics.length <= aPageSize) {

                aPageClinics = this.state.clinics.slice(0, this.state.clinics.length);
            }
            this.setState({ page: { pageSize: aPageSize, pageClinics: aPageClinics, totalPages: aTotalPages, pageNumber: activePage } }, () => {
                this.setState({
                    isLoading: true
                });
            });
        }
    }

    handlePaginationClick(event) {
        event.preventDefault();
        let aPageNumber = event.target.name;
        let aPageSize = this.state.page.pageSize;

        if (aPageNumber <= 0) {
            aPageNumber = 1;
        }
        if (aPageNumber > this.state.page.totalPages) {
            aPageNumber = this.state.page.totalPages;
        }

        let startIndex = (aPageNumber - 1) * aPageSize;
        let endIndex = startIndex + aPageSize;
        if (endIndex > this.state.clinics.length) {
            endIndex = startIndex + this.state.clinics.length - 1;
        }
        let aPageClinics = this.state.clinics.slice(startIndex, endIndex);

        this.setState({ page: { pageSize: aPageSize, pageClinics: aPageClinics, totalPages: this.state.page.totalPages, pageNumber: aPageNumber } });
    }

    sortTable(event,sortTarget) {
        event.preventDefault();
        const sortedClinics = this.state.clinics.sort((a,b) =>{
            let valueA;
            let valueB;

            switch (sortTarget){
                case "clinicId": 
                    valueA = a.clinicId;
                    valueB = b.clinicId;
                    break;
                case "name": 
                   valueA = a.name.toUpperCase();
                    valueB = b.name.toUpperCase();
                    break;
                case "address": 
                    valueA = (a.physicalAddressLine1 + a.physicalAddressLine2).toUpperCase();
                    valueB = (b.physicalAddressLine1 + b.physicalAddressLine2).toUpperCase();
                    break;
                case "city": 
                    valueA = a.physicalCity.toUpperCase();
                    valueB = b.physicalCity.toUpperCase();
                    break;
                case "postCode": 
                    valueA = a.physicalPostCode.toUpperCase().replace(' ', '');
                    valueB = b.physicalPostCode.toUpperCase().replace(' ', '');
                    break;
                case "phone1": 
                    valueA = a.phone1.toUpperCase().replace(/[^0-9]/g, '');
                    valueB = b.phone1.toUpperCase().replace(/[^0-9]/g, '');
                    break;
                case "serviceType": 
                    valueA = a.serviceType.toUpperCase();
                    valueB = b.serviceType.toUpperCase();
                    break;
            }
            if (valueA < valueB)
                return -1
            if (valueA > valueB)
                return 1
            else return 0
        })

        let imgTag;

        switch (sortTarget){
            case "clinicId": 
                imgTag = document.getElementById("clinicIdSortIcon");
                break;
            case "name": 
                imgTag = document.getElementById("nameSortIcon");
                break;
            case "address": 
                imgTag = document.getElementById("addressSortIcon");
                break;
            case "city": 
                imgTag = document.getElementById("citySortIcon");
                break;
            case "postCode": 
                imgTag = document.getElementById("postCodeSortIcon");
                break;
            case "phone1": 
                imgTag = document.getElementById("phone1SortIcon");
                break;
            case "serviceType": 
                imgTag = document.getElementById("serviceTypeSortIcon");
                break;
        }
        if (imgTag.sortType == "init" || imgTag.sortType == "down"){
            imgTag.src = "https://i.ibb.co/5hTRFft/sort-up.png";
            imgTag.sortType = "up";   
            sortedClinics.reverse();
        }else{
            imgTag.src = "https://i.ibb.co/Pt8qtbJ/sort-down.png";
            imgTag.sortType = "down";
        }

        this.setState({
            clinics: sortedClinics
        }, () => {
            this.initilizePagination();
        });
    }


    render() {
        if (this.state.isLoading === false) {
            return (<p><em>Loading...</em></p>);
        } else {
            let active = parseInt(this.state.page.pageNumber);
            let pageItems = [];
            let pageItem = {};
            for (let number = 1; number <= this.state.page.totalPages; number++) {
                if (number === active) {
                    pageItem = (
                        <li className="page-item active">
                            <a className="page-link" href="#" onClick={this.handlePaginationClick} name={number} >{number}</a>
                        </li>);
                } else {
                    pageItem = (
                        <li className="page-item">
                            <a className="page-link" href="#" onClick={this.handlePaginationClick} name={number} >{number}</a>
                        </li>);
                }
                pageItems.push(pageItem);
            }

            return (

                <div>
                    <Row>
                        <Col sm={6}>
                            <InputGroup className="mb-3">
                                <FormControl placeholder="Search" aria-label="Search" aria-describedby="basic-addon1" class="mb-3" ref={this.searchTextInput} />
                                <InputGroup.Append>
                                    <Button variant="outline-primary" onClick={this.handleClick}>Search</Button>
                                </InputGroup.Append>
                            </InputGroup>
                        </Col>
                        <Col sm={15}>
                             <pre>  </pre>
                        </Col>
                        <Col sm={15}>
                            <DropdownButton blinks={[{text: "Download Excel", link: "/download"}]} />
                        </Col>
                        <Col sm={15}>
                             <pre>  </pre>
                        </Col>
                        <Col sm={30}>
                            <DropdownButton blinks={[{ action: "Add", text: "Add new Clinic", link: "/clinic/add"}]} />
                        </Col>
                    </Row>
                    <Row>

                        <Col sm={12}>
                            <Table striped bordered hover>
                                <thead>
                                    <tr>
                                        <th scope="col">Options</th>
                                        {/* <th scope="col">#</th> */}
                                        <th scope="col">
                                            Clinic ID
                                            <img src="https://i.ibb.co/zSfCgMC/Sort-both.png" 
                                                 alt="sort" 
                                                 height="15" width="20"
                                                 onClick={(e) => this.sortTable(e,"clinicId")}
                                                 id="clinicIdSortIcon"
                                                 sortType="init"/>
                                        </th>
                                        <th scope="col">
                                            Clinic Name 
                                            <img src="https://i.ibb.co/zSfCgMC/Sort-both.png" 
                                                 alt="sort" 
                                                 height="15" width="20"
                                                 onClick={(e) => this.sortTable(e,"name")}
                                                 id="nameSortIcon"
                                                 sortType="init"/>
                                        </th>
                                        <th scope="col">
                                            Address
                                            <img src="https://i.ibb.co/zSfCgMC/Sort-both.png" 
                                                 alt="sort" 
                                                 height="15" width="20"
                                                 onClick={(e) => this.sortTable(e,"address")}
                                                 id="addressSortIcon"
                                                 sortType="init"/>
                                        </th>
                                        <th scope="col">
                                            City
                                            <img src="https://i.ibb.co/zSfCgMC/Sort-both.png" 
                                                 alt="sort" 
                                                 height="15" width="20"
                                                 onClick={(e) => this.sortTable(e,"city")}
                                                 id="citySortIcon"
                                                 sortType="init"/>
                                        </th>
                                        <th scope="col">
                                            PostCode                                        
                                            <img src="https://i.ibb.co/zSfCgMC/Sort-both.png" 
                                                 alt="sort" 
                                                 height="15" width="20"
                                                 onClick={(e) => this.sortTable(e,"postCode")}
                                                 id="postCodeSortIcon"
                                                 sortType="init"/>
                                        </th>
                                        <th scope="col">
                                            Phone1
                                            <img src="https://i.ibb.co/zSfCgMC/Sort-both.png" 
                                                 alt="sort" 
                                                 height="15" width="20"
                                                 onClick={(e) => this.sortTable(e,"phone1")}
                                                 id="phone1SortIcon"
                                                 sortType="init"/>
                                        </th>
                                        {/* <th scope="col">Phone2</th> */}
                                        {/* <th scope="col">Website</th> */}
                                        {/* <th scope="col">Email</th> */}
                                        <th scope="col">
                                            Service Type
                                            <img src="https://i.ibb.co/zSfCgMC/Sort-both.png" 
                                                 alt="sort" 
                                                 height="15" width="20"
                                                 onClick={(e) => this.sortTable(e,"serviceType")}
                                                 id="serviceTypeSortIcon"
                                                 sortType="init"/>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {
                                        this.state.page.pageClinics.map((clinic, index) => {
                                            return (
                                                <tr key={clinic.clinicId}>
                                                    <td>
                                                        <DropdownButton blinks={
                                                            [{ action: "View", text: "View", link: '/clinic/view/' +active+'/'+ clinic.clinicId},
                                                                { action: "Edit", text: "Edit", link: "/clinic/edit/" + active + '/'+ clinic.clinicId},
                                                                { action: "Delete", text: "Delete", link: "/clinic/delete/" + active + '/'+ clinic.clinicId}]} />
                                                    </td>
                                                    {/* <th scope="row">{index}</th> */}
                                                    <td>{clinic.clinicId}</td>
                                                    <td>{clinic.name}</td>
                                                    <td>{clinic.physicalAddressLine1}, {clinic.physicalAddressLine2}</td>
                                                    <td>{clinic.physicalCity}</td>
                                                    <td>{clinic.physicalPostCode}</td>
                                                    <td>{clinic.phone1}</td>
                                                    {/* <td>{clinic.phone2}</td> */}
                                                    {/* <td>{clinic.website}</td> */}
                                                    {/* <td>{clinic.email1}</td> */}
                                                    <td>{clinic.serviceType}</td>

                                                </tr>);
                                        })
                                    }
                                </tbody>
                            </Table>
                        </Col>
                    </Row>
                    <Row>
                        <Col sm="12">
                            <nav aria-label="...">
                                <ul className="pagination">
                                    <li className="page-item">
                                        <a className="page-link" href="#" tabIndex="-1" onClick={this.handlePaginationClick} name={parseInt(this.state.page.pageNumber) - 1} >Previous</a>
                                    </li>
                                    {pageItems}
                                    <li className="page-item">
                                        <a className="page-link" href="#" onClick={this.handlePaginationClick} name={parseInt(this.state.page.pageNumber) + 1} >Next</a>
                                    </li>
                                </ul>
                            </nav>
                        </Col>
                    </Row>
                </div>
            );
        }
    }
});