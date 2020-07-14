import React, { Component } from 'react';
import { withRouter, Link } from 'react-router-dom';
import { Row, Col, Form, Button } from 'react-bootstrap';
import { SelectDropDown } from './SelectDropDown';
import AddClinicHour from './AddClinicHour';
import { AuthService } from '../service/AuthService';
 
export default withRouter(class ClinicHour extends Component {

    constructor(props) {
        super(props);
        this.state = {
            clinicHours: [],
            options: [],
            isClinicLoading: false,
            isDaysLoading: false
        };
        this.handleUpdateChange = this.handleUpdateChange.bind(this);
        this.handleUpdateSubmit = this.handleUpdateSubmit.bind(this);
        this.handleDeleteSubmit = this.handleDeleteSubmit.bind(this);
        this.handleSelectListChange = this.handleSelectListChange.bind(this);

        if (AuthService.isAuth() === false) {
            this.props.history.push('/login');
        }

        const action = String(this.props.match.params.action);

        if (action.toUpperCase()==="VIEW" || action.toUpperCase() === "EDIT" || action.toUpperCase() === "DELETE") {
            const api = "/api/ClinicHour/GetClinicHours/";
            const clinicId = this.props.match.params.clinicID;
            console.log(clinicId);
            fetch(api + clinicId, {
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
                    console.log(data);                    
                    if (data !== null) {
                        let sortedClinicHours = data.sort((a,b) => {
                            let valueA = a.daysOfTheWeekId;
                            let valueB = b.daysOfTheWeekId;
                            if (valueA < valueB)
                                return -1
                            if (valueA > valueB)
                                return 1
                            else return 0
                        });
                        this.setState({ clinicHours: sortedClinicHours, isClinicLoading: true });
                    }
                }).catch(err => console.log(err));

            const api1 = "api/DaysOfWeek/GetDaysOfWeeks";
            fetch(api1, {
                method: "GET",
                headers: {
                    "content-type": "application/json",
                    "authorization": "Bearer " + AuthService.token()
                },
            }).
                then(response => {
                    if (response.status === 401) {
                        AuthService.logout();
                        this.props.history.push('/login');
                    } else {
                        return response.json();
                    }
                }).
                then(data => {
                    this.setState({ options: data, isDaysLoading: true });
                }).catch(err => console.log(err));

        } else {
            const api2 = "api/DaysOfWeek/GetDaysOfWeeks";
            fetch(api2, {
                method: "GET",
                headers: {
                    "content-type": "application/json",
                    "authorization": "Bearer " + AuthService.token()
                },
            }).
                then(response => {
                    if (response.status === 401) {
                        AuthService.logout();
                        this.props.history.push('/login');
                    } else {
                        return response.json();
                    }
                }
                ).
                then(data => {
                    console.log(data);
                    if (data !== null) {
                        this.setState({ options: data, isDaysLoading: true });
                    } 
                }).catch(err => console.log(err));
        }

     
    }

    handleUpdateSubmit(event) {
        event.preventDefault();
        const api6 = "api/ClinicHour/UpdateClinicHour/";
        const clinicHourID = event.target.name;
        let clinicHour = this.state.clinicHours.find((element) => {
            if (element.tClinicHoursId == clinicHourID) {
                return element;
            }
        });
        fetch(api6, {
            method: "PUT",
            headers: {
                "content-type": "application/json",
                "authorization": "Bearer " + AuthService.token()
            },
            body: JSON.stringify(clinicHour)
        }).then(response => {            
            if (response.status === 401) {
                AuthService.logout();
                this.props.history.push('/login');
            } else {
                window.location.reload();
                return response.json();
            }
        }).catch(err => console.log(err));
    }

    handleUpdateChange(aClinicHourID,event) {
        event.preventDefault();
        const aName = event.target.name;
        const aValue = event.target.value;
        let items = this.state.clinicHours;   
        let item = this.state.clinicHours.find(element => {
            if (element.tClinicHoursId === aClinicHourID) {                
                return element;
            }
        });

        let index = items.indexOf(item);
        if (String(aName).toUpperCase() === "STARTTIME") {
            item.startTime = aValue;
        }

        if (String(aName).toUpperCase() === "ENDTIME") {
            item.endTime = aValue;
        }

        items[index] = item;

        this.setState({ clinicHours: items });

    }

    handleDeleteSubmit(event) {
        event.preventDefault();
        if (event.target.name === "all") {
            const api3 = "api/ClinicHour/DeleteClinicHours/";
            fetch(api3, {
                method: "DELETE",
                headers: {
                    "content-type": "application/json",
                    "authorization": "Bearer " + AuthService.token()
                },
            })
                .then(response => {
                    if (response.status === 401) {
                        AuthService.logout();
                        this.props.history.push('/login');
                    } else {
                        window.location.reload();
                        return response.json();
                    }
                })
                .catch(err => console.log(err));
        } else {
            const clinicHourId = event.target.name;
            const api4 = "api/ClinicHour/DeleteClinicHours/" + clinicHourId;
            fetch(api4, {
                method: "DELETE",
                headers: {
                    "content-type": "application/json",
                    "authorization": "Bearer " + AuthService.token()
                },
            })
                .then(response => {
                    if (response.status === 401) {
                        AuthService.logout();
                        this.props.history.push('/login');
                    } else {
                        window.location.reload();
                        return response.json();
                    }
                })
                .catch(err => console.log(err));
            //Obtain new Clinic hours again
            this.setState({ isClinicLoading: false });
            const api5 = "api/ClinicHour/GetClinicHours/";
            const clinicId = this.props.match.params.clinicID;
            fetch(api5 + clinicId, {
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
                    let sortedClinicHours = data.sort((a,b) => {
                        let valueA = a.daysOfTheWeekId;
                        let valueB = b.daysOfTheWeekId;
                        if (valueA < valueB)
                            return -1
                        if (valueA > valueB)
                            return 1
                        else return 0
                    });       
                    this.setState({ clinicHours: sortedClinicHours, isClinicLoading: true });
                }).catch(err => console.log(err));
        }
    }

    handleSelectListChange(selectedValue,aClinicHourID) {
        
        this.setState({ selectedDropDownValue : selectedValue });

        let items = this.state.clinicHours;   
        let item = this.state.clinicHours.find(element => {
            if (element.tClinicHoursId === aClinicHourID) {                
                return element;
            }
        });

        let index = items.indexOf(item);
        if (index != -1) {
            item.day = selectedValue;
            item.daysOfTheWeekId = selectedValue;
        }

        items[index] = item;

        this.setState({ clinicHours: items });
    }
    
    render() {

        let action = String(this.props.match.params.action);
        const activePage = this.props.match.params.page;
        let editStyle = {};
        let deleteStyle = {};
        let disabled = false;
        action = action.toUpperCase();
        switch (action) {
            case "EDIT":
                deleteStyle.display = "none";
                editStyle.display = "inline";
                disabled = false;
                break;
            case "DELETE":
                deleteStyle.display = "inline";
                editStyle.display = "none";
                disabled = true;
                break;
            case "VIEW":
                editStyle.display = "none";
                deleteStyle.display = "none";
                disabled = true;
                break;
            default:
                editStyle.display = "none";
                deleteStyle.display = "none";
                disabled = false;
                break;
        }


        if (this.state.isClinicLoading === false && this.state.isDaysLoading === false) {
            return (
                <p><em>Loading...</em></p>
            );
        }

        if (action === "ADD") {
            return (
                <AddClinicHour clinicId={this.props.match.params.clinicID} options={this.state.options} page={activePage} />
            );
        }

        let messageStyle = {};
        if (this.state.clinicHours.length === 0) {
            messageStyle.display = "inline";
        } else {
            messageStyle.display = "none";
        }

        return (
            <div>
                <Row>
                    <Col sm={12} >
                        <div style={editStyle}>
                            <Link to={'/clinichour/add/' + activePage + '/' + this.props.match.params.clinicID} >
                                <Button type="button" className="float-left mb-3 mr-2">Add New Clinic Hour</Button>
                            </Link>
                        </div>
                        <Link to={'/clinic/' + action.toLowerCase() + '/' + activePage+'/'+ this.props.match.params.clinicID} >
                            <Button type="button" className="float-left mb-3" >Back</Button>
                        </Link>
                    </Col>
                </Row>
                <Row>
                    <Col sm={12}>
                        <div style={messageStyle}>
                            <h1>
                                <p>There is no Clinic Hour available ,please create new clinic hour!</p>
                            </h1>
                        </div>
                    </Col>
                </Row>
                <Row>
                    <Col sm={12}>
                        {this.state.clinicHours.map(clinicHour => {
                            return (
                                <Form as={Row}>
                                    <Col sm={1}>
                                        <Form.Label>Days:</Form.Label>
                                    </Col>
                                    <Col sm={2}>
                                        <SelectDropDown 
                                            selected={clinicHour.day} 
                                            options={this.state.options} 
                                            disabled={disabled} 
                                            onSelectedListChange={(v) => this.handleSelectListChange(v,clinicHour.tClinicHoursId)}
                                        />
                                    </Col>
                                    <Col sm={1}>
                                        <Form.Label>Start Time:</Form.Label>
                                    </Col>
                                    <Col sm={2}>
                                        <Form.Control as="input" readOnly={disabled} type="text" name="StartTime" value={clinicHour.startTime}
                                            clinicHourID={clinicHour.tClinicHoursId} onChange={(e) => this.handleUpdateChange(clinicHour.tClinicHoursId, e)} />
                                    </Col>
                                    <Col sm={1}>
                                        <Form.Label >End Time:</Form.Label>
                                    </Col>
                                    <Col sm={2}>
                                        <Form.Control as="input" readOnly={disabled} type="text" name="EndTime" value={clinicHour.endTime}
                                            clinicHourID={clinicHour.tClinicHoursId} onChange={(e) => this.handleUpdateChange(clinicHour.tClinicHoursId, e)} />
                                    </Col>
                                    <Col sm={3}>                                        
                                        <div style={deleteStyle}>
                                            <Button as="input" className="float-left" type="submit" value="Delete" onClick={this.handleDeleteSubmit} name={clinicHour.tClinicHoursId} />
                                        </div>
                                        <div style={editStyle}>
                                            <Button as="input" className="float-left" type="submit" value="Update" onClick={this.handleUpdateSubmit} name={clinicHour.tClinicHoursId} />
                                        </div>
                                    </Col>
                                </Form>
                            );
                        })
                        }
                    </Col>
                </Row>
                <Row>
                    <div >
                        <font color="red">
                            Note: Conflicting week days are not allowed.
                        </font>
                    </div>
                </Row>
            </div>

            );
       
    }
});