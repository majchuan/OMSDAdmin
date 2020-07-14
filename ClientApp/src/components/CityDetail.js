import React, { Component } from 'react';
import { Row, Col, Form, FormGroup, FormControl, FormLabel, Button, FormCheck, Alert, FormText } from 'react-bootstrap';
import { withRouter} from 'react-router-dom';
import { DropdownButton } from './DropdownButton';
import { AuthService } from '../service/AuthService';
import Message from './Message';


export default withRouter(class CityDetail extends Component {

    constructor(props) {
        super(props);
        this.state = {
            city: {
                name: "",
                lat:"",               
                long:""
            },
            isEdit: false,
            isLoading: false
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleBackButton = this.handleBackButton.bind(this);

        if (AuthService.isAuth() === false) {
            this.props.history.push('/login');
        }
    }

    componentDidMount() {
        const ontarioCityId = this.props.match.params.id;
        if (ontarioCityId !== null && this.props.match.params.action !== "add") {
            const cityIsEdit = (this.props.match.params.action === 'view' || this.props.match.params.action === 'delete') ? true : false;
            const API = '/api/OntarioCity/GetCity/';
            fetch(API + ontarioCityId, {
                method: "GET",
                headers: {
                    "content-type": "application/json",
                    "authorization": "Bearer " + AuthService.token()
                }
            }).then(response => {
                    if (response.status === 401) {
                        AuthService.logout();
                        //this.props.history.push('/login');
                    } else {
                        return response.json();
                    }
            }).then(data => {
                this.setState({ city: data, isEdit: cityIsEdit }, () => {
                    this.setState({
                        isLoading: true
                    });
                });
            }).catch(exception => console.log(exception));
                

        }
    }

    handleChange(event){
        event.preventDefault();
        var aCity = {};

        switch (event.target.name) {
            case 'name':
                aCity = this.state.city;
                aCity.name = event.target.value;
                break;
            case 'lat':
                aCity = this.state.city;
                aCity.lat = event.target.value;
                break;
            case 'long':
                aCity = this.state.city;
                aCity.long = event.target.value;
                break;
            default:
                aCity = this.state.city;
                break;
        }
        this.setState({ city: aCity });
    }

    handleSubmit(event) {
        event.preventDefault();
        if (true) {
            const lowerAction = this.props.match.params.action.toLowerCase()

            switch (lowerAction) {
                case 'edit':
                    fetch('/api/OntarioCity/UpdateCity', {
                        method: 'PUT',
                        body: JSON.stringify(this.state.city),
                        headers: {
                            'content-type': 'application/json',
                            "authorization": "Bearer " + AuthService.token()
                        }
                    }).then(response => {
                        if (response.status === 200) {
                            
                            return response.json();
                        }
                    }).then(data => {   
                        this.props.history.push('/city');

                    }).catch(
                        err => console.log(err)
                    );
                    break;
                case 'delete':
                    fetch('/api/OntarioCity/DeleteCity/' + this.state.city.ontarioCityId, {
                        method: 'DELETE',
                        headers: {
                            'content-type': 'application/json',
                            "authorization": "Bearer " + AuthService.token()
                        }
                    }).then(response => {
                        if (response.status === 200) {
                            this.props.history.push('/city');
                            return response.json();
                            
                        }
                    }).catch(err => console.log(err));
                    break;
                case 'add':
                    
                    fetch('/api/OntarioCity/AddCity', {
                        method: 'POST',
                        body: JSON.stringify(this.state.city),
                        headers: {
                            'content-type': 'application/json',
                            "authorization": "Bearer " + AuthService.token()
                        }
                    }).then(response => {
                        if (response.status === 200) {
                            return response.json();
                        }

                    }).then(data => {
                        this.props.history.push('/city');
                    }).catch(
                        err => console.log(err)
                    );
                    break;
            }
        }


    }

    handleBackButton(event) {
        event.preventDefault();
        const activePage = this.props.match.params.page;

        if (activePage === undefined) {
            this.props.history.push('/city');
        } else {
            this.props.history.push('/city/' + activePage);
        }
    }



    render() {
        let style = {};
        let blinks_Option_Button = [];
        const activePage = this.props.match.params.page;
        switch (this.props.match.params.action) {
            case "view":
                style.display = 'none';
                break;
            case "edit":
                style.display = 'block';
                break;
            case "add":
                style.display = 'block';
                break;
            case "delete":
                style.display = 'block';
                break;

        }
        return (
            <div>
                <div>
                    <Row>
                        <Col sm={12}>
                            <Button type="button" className="float-right mb-3" onClick={this.handleBackButton}>Back</Button>
                        </Col>
                    </Row>
                </div>
                <div>
                <Form onSubmit={this.handleSubmit}>
                    <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                            City Name
                            <font color="red" style={{display: this.state.isEdit ? 'none' : 'inline' }} >*</font>
                        </FormLabel>
                        <Col sm={8}>
                            <FormControl readOnly={this.state.isEdit} as='input' type='text' value={this.state.city.name} name="name" onChange={this.handleChange} />
                        </Col>
                    </FormGroup>
                    <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                            Lat
                            <font color="red" style={{display: this.state.isEdit ? 'none' : 'inline' }} >*</font>
                        </FormLabel>
                        <Col sm={8}>
                        <FormControl readOnly={this.state.isEdit} as='input' type='text' 
                                value={this.state.city.lat} 
                                placeholder={ this.state.city.lat }
                                name="lat"
                                onChange={this.handleChange} />
                        </Col>
                    </FormGroup>
                    <FormGroup as={Row}>
                        <FormLabel column sm={4} className="text-right">
                            Long
                            <font color="red" style={{display: this.state.isEdit ? 'none' : 'inline' }} >*</font>
                        </FormLabel>
                        <Col sm={8}>
                        <FormControl readOnly={this.state.isEdit} as='input' type='text' value={this.state.city.long}
                                value={this.state.city.long}
                                name='long'
                                onChange={this.handleChange} />
                        </Col>
                    </FormGroup>
                   
                    <FormGroup as={Row}>
                        <Col sm={{ span: 8, offset: 4 }}>
                            <div style={style}>
                                <FormText column sm={4} className="text-left">
                                    <font color="red" size="+2">
                                        {this.props.match.params.action === 'delete' ? "WARNING: THE DELETION OF THIS CITY CAN NOT BE REVERTED." : ""}  
                                    </font>
                                </FormText>
                                <Button type='submit' variant={this.props.match.params.action === 'delete' ? "danger" : "primary"}>
                                    {this.props.match.params.action === 'delete' ? "Confirm Delete" : "Submit"}
                                </Button>
                            </div>
                        </Col>
                    </FormGroup>
                </Form>
                </div>
            </div>
        );
    }
});




