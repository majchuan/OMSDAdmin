import React, { Component } from 'react';
import { Row, Col, Form, FormGroup, FormControl, FormLabel, Button, FormCheck, Alert, FormText } from 'react-bootstrap';
import { withRouter} from 'react-router-dom';
import { DropdownButton } from './DropdownButton';
import { AuthService } from '../service/AuthService';
import Message from './Message';


export default withRouter(class ServiceTypeDetail extends Component {

    constructor(props) {
        super(props);
        this.state = {
            serviceType: {
                name: "",
                image:""
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
        const serviceTypeId = this.props.match.params.id;
        if (serviceTypeId !== null && this.props.match.params.action !== "add") {
            const serviceTypeIsEdit = (this.props.match.params.action === 'view' || this.props.match.params.action === 'delete') ? true : false;
            const API = '/api/ServiceType/GetServiceType/';
            fetch(API + serviceTypeId, {
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
                this.setState({ serviceType: data, isEdit: serviceTypeIsEdit }, () => {
                    this.setState({
                        isLoading: true
                    });
                });
            }).catch(exception => console.log(exception));
                

        }
    }

    handleChange(event){
        event.preventDefault();
        var aServiceType = {};

        switch (event.target.name) {
            case 'name':
                aServiceType = this.state.serviceType;
                aServiceType.name = event.target.value;
                break;
            case 'image':
                aServiceType = this.state.serviceType;
                aServiceType.image = event.target.value;
                break;
            default:
                aServiceType = this.state.serviceType;
                break;
        }
        this.setState({ serviceType: aServiceType });
    }

    handleSubmit(event) {
        event.preventDefault();
        if (true) {
            const lowerAction = this.props.match.params.action.toLowerCase()

            switch (lowerAction) {
                case 'edit':

                    fetch('/api/ServiceType/UpdateServiceType', {
                        method: 'PUT',
                        body: JSON.stringify(this.state.serviceType),
                        headers: {
                            'content-type': 'application/json',
                            "authorization": "Bearer " + AuthService.token()
                        }
                    }).then(response => {
                        if (response.status === 200) {
                            
                            return response.json();
                        }
                    }).then(data => {   
                        this.props.history.push('/servicetype');

                    }).catch(
                        err => console.log(err)
                    );
                    break;
                case 'delete':
                    fetch('/api/ServiceType/DeleteServiceType/' + this.state.serviceType.serviceTypeId, {
                        method: 'DELETE',
                        headers: {
                            'content-type': 'application/json',
                            "authorization": "Bearer " + AuthService.token()
                        }
                    }).then(response => {
                        if (response.status === 200) {
                            this.props.history.push('/servicetype');
                            return response.json();
                            
                        }
                    }).catch(err => console.log(err));
                    break;
                case 'add':
                    
                    fetch('/api/ServiceType/AddServiceType', {
                        method: 'POST',
                        body: JSON.stringify(this.state.serviceType),
                        headers: {
                            'content-type': 'application/json',
                            "authorization": "Bearer " + AuthService.token()
                        }
                    }).then(response => {
                        if (response.status === 200) {
                            return response.json();
                        }
                    }).then(data => {
                        this.props.history.push('/serviceType');
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
            this.props.history.push('/servicetype');
        } else {
            this.props.history.push('/servicetype/' + activePage);
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
                            Name
                            <font color="red" style={{display: this.state.isEdit ? 'none' : 'inline' }} >*</font>
                        </FormLabel>
                        <Col sm={8}>
                            <FormControl readOnly={this.state.isEdit} as='input' type='text' value={this.state.serviceType.name} name="name" onChange={this.handleChange} />
                        </Col>
                    </FormGroup>
                    <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                            Image
                            <font color="red" style={{display: this.state.isEdit ? 'none' : 'inline' }} >*</font>
                        </FormLabel>
                        <Col sm={8}>
                        <FormControl readOnly={this.state.isEdit} as='input' type='text' 
                                value={this.state.serviceType.image} 
                                placeholder={ this.state.serviceType.image }
                                name="image"
                                onChange={this.handleChange} />
                        </Col>
                    </FormGroup>
                   
                    <FormGroup as={Row}>
                        <Col sm={{ span: 8, offset: 4 }}>
                            <div style={style}>
                                <FormText column sm={4} className="text-left">
                                    <font color="red" size="+2">
                                        {this.props.match.params.action === 'delete' ? "WARNING: THE DELETION OF THIS SERVICE TYPE CAN NOT BE REVERTED." : ""}  
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




