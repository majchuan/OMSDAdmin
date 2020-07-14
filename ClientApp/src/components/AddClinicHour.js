import React, { Component } from 'react';
import { Form, Row, Col, Button } from 'react-bootstrap';
import { SelectDropDown } from './SelectDropDown';
import { AuthService } from '../service/AuthService';
import Message from './Message';
import { withRouter, Link } from 'react-router-dom';
import { ValidateClinicHour } from '../service/ValidateClinicHour';

export default withRouter(class AddClinicHour extends Component {
    constructor(props) {
        super(props);
        this.state = {
            clinicHours: [],
            hasError: false,
            error: {
                message:""
            },
            selectedDropDownValue : 1
        };
        this.inputStartTimeRef = React.createRef();
        this.inputEndTimeRef = React.createRef();
        this.handleAddSubmit = this.handleAddSubmit.bind(this);
        this.initClinicHours = this.initClinicHours.bind(this);
        this.handleSelectListChange = this.handleSelectListChange.bind(this);
        if (AuthService.isAuth === false) {
            this.props.history.push('/login');
        }
        
        this.initClinicHours();

    }

    initClinicHours() {
        const clinicId = this.props.clinicId;
        const api = '/api/ClinicHour/GetClinicHours/';
        fetch(api + clinicId, {
            method: "GET",
            headers: {
                "content-type": "application/json",
                "authorization": "Bearer " + AuthService.token()
            }
        }).then(response => {
            if (response.status === 401) {
                this.props.history.push('/login');
            } else {
                return response.json();
            }
        }).then(data => {
            this.setState({
                clinicHours: data
            });
        }).catch(err => console.log(err));
    }

    handleAddSubmit(event) {
        event.preventDefault();
        const day = this.state.selectedDropDownValue;
        const startTime = this.inputStartTimeRef.current.value;
        const endTime = this.inputEndTimeRef.current.value;
        const clinicId = this.props.clinicId;
        const valueEmptyStartTimeError = ValidateClinicHour.isEmpty(startTime);
        const valueEmptyEndTimeError = ValidateClinicHour.isEmpty(endTime);
        if (valueEmptyEndTimeError.hasError === true || valueEmptyStartTimeError.hasError === true) {
            this.setState({
                hasError: true,
                error: {
                    message: "StartTime: " + valueEmptyStartTimeError.message + " EndTime:" + valueEmptyEndTimeError.message
                }
            });
        } else {
            const dayError = ValidateClinicHour.validateDay(day, ...this.state.clinicHours);
            const timeError = ValidateClinicHour.compareTime(startTime, endTime);
            if (dayError.hasError === false && timeError.hasError === false) {
                let clinicHour = {
                    tClinicHoursId: -1,
                    editstate: 0,
                    clinicId: clinicId,
                    dataCreated: new Date(),
                    startTime: startTime,
                    endTime: endTime,
                    day: day,
                    dayOfTheWeekId: day,
                    dayofTheWeeekName: '',
                    daysOfTheWweekAbbre: ''
                };

                const api = "/api/ClinicHour/CreateClinicHour/";
                fetch(api, {
                    method: "POST",
                    body: JSON.stringify(clinicHour),
                    headers: {
                        "content-type": "application/json",
                        "authorization": "Bearer " + AuthService.token()
                    }
                }).then(response => {
                        if (response.status === 401) {
                            this.props.history.push('/login');
                        }
                        if (response.status === 200){
                            this.props.history.push('/clinichour/edit/' + this.props.page + '/' + this.props.clinicId);
                        }
                }).catch(err => console.log(err));
            } else {
                this.setState({
                    hasError: true,
                    error: {
                        message: dayError.message + " " + timeError.message
                    }
                });
            }
        }
       

    }

    handleSelectListChange(selectedValue) {
        this.setState({ selectedDropDownValue : selectedValue });
    }

    render() {
        let activePage = this.props.page;
        if (activePage === undefined) {
            activePage = this.props.match.params.page;
        }
        if (this.state.hasError) {
            return (
                <div>
                    <Row>
                        <Col sm={12}>
                            <div>
                                <Link to={'/clinichour/edit/' + activePage + '/' + this.props.clinicId} >
                                    <Button type="button" className="float-left mb-3 mr-2" >Back</Button>
                                </Link>
                            </div>
                        </Col>
                    </Row>
                    <Row>
                        <Col sm={12}>
                            <Message message={this.state.error.message} />
                        </Col>
                    </Row>
                </div>
                );
        }
        return (
            <div>
                <Row>
                    <Col sm={12}>
                        <div>
                            <Link to={'/clinichour/edit/' + activePage + '/' + this.props.clinicId} >
                                <Button type="button" className="float-left mb-3 mr-2" >Back</Button>
                            </Link>
                        </div>
                     </Col>
                </Row>
                <Row>
                    <Col sm={12}>
                        <Form>
                            <Form.Group as={Row} controlId="formNewClinicHours">
                                <Form.Label column sm={2}>Days</Form.Label>
                                <Col sm={6}>
                                    <SelectDropDown type="days" selected={1} options={this.props.options} disabled={false} onSelectedListChange={this.handleSelectListChange} />
                                </Col>
                            </Form.Group>
                            <Form.Group as={Row} controlId="formNewClinicHours">
                                <Form.Label column sm={2}>Start Time:</Form.Label>
                                <Col sm="6">
                                    <Form.Control type="input" ref={this.inputStartTimeRef} />
                                </Col>
                            </Form.Group>
                            <Form.Group as={Row} controlId="formNewClinicHours">
                                <Form.Label column sm={2}>End Time:</Form.Label>
                                <Col sm="6">
                                    <Form.Control type="input" ref={this.inputEndTimeRef} />
                                </Col>
                            </Form.Group>
                            <Form.Group as={Row} controlId="formNewClinicHours">
                                <Col sm={{ span: 10, offset: 2 }}>
                                    <Button type="submit" onClick={this.handleAddSubmit}>Add New Clinic Hour</Button>
                                </Col>
                            </Form.Group>
                        </Form>
                    </Col>
                </Row>
            </div>
        );
    }
});