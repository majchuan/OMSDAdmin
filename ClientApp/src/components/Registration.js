import React, { Component } from "react";
import { Row, Col, Form, Button } from "react-bootstrap";
import { withRouter } from 'react-router-dom';
import { AuthService } from '../service/AuthService';

export default withRouter(class Registration extends Component {
    constructor(props) {
        super(props);
        if (AuthService.isAuth() === false) {
            this.props.history.push('/login');
        }
        this.state = {
            user: {
                userId : 0,
                email: "",
                password: "",
                userFirstName: "",
                userLastName: "",
                address: "",
                city: "",
                province: "",
                postCode: "",
                phoneNumber: "",
                message: "",
                token:""
            },
            isLoading: false
        };
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        const api = "api/User/Register";
        //alert(JSON.stringify(this.state.user));
        if (this.state.user.password.length > 0) {
            fetch(api, {
                method: "POST",
                headers: {
                    "content-type": "application/json"
                },
                body: JSON.stringify(this.state.user)
            }).then(response => {
                if (response.status === 200) {
                    this.props.history.push('/login');
                }
            }).catch(err => console.log(err));
        }
    }

    handleChange(event) {
        event.preventDefault();
        const name = event.target.name;
        const value = event.target.value;
        let aUser = {};
        switch (name) {
            case "email":
                aUser = this.state.user;
                aUser.email = value;
                break;
            case "password":
                aUser = this.state.user;
                aUser.password = value;
                break;
            case "firstName":
                aUser = this.state.user;
                aUser.userFirstName = value;
                break;
            case "lastName":
                aUser = this.state.user;
                aUser.userLastName = value;
                break;
            case "street":
                aUser = this.state.user;
                aUser.address = value;
                break;
            case "city":
                aUser = this.state.user;
                aUser.city = value;
                break;
            case "province":
                aUser = this.state.user;
                aUser.province = value;
                break;
            case "postCode":
                aUser = this.state.user;
                aUser.postCode = value;
                break;
            case "phoneNumber":
                aUser = this.state.user;
                aUser.phoneNumber = value;
                break;
        }

        this.setState({
            user: aUser
        });
    }

    render() {
        return (
            <div>
                <Form onSubmit={this.handleSubmit}>
                    <Form.Group as={Row} controlId="email">
                        <Form.Label column={2}>Email</Form.Label>
                        <Col sm={10}>
                            <Form.Control type="email" placeholder="Email" name="email" onChange={this.handleChange} />
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row} controlId="password">
                        <Form.Label column={2}>Password</Form.Label>
                        <Col sm={10}>
                            <Form.Control type="password" placeholder="Password" name="password" onChange={this.handleChange} />
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row} controlId="name">
                        <Col sm={6}>
                            <Row>
                                <Col sm={4}>
                                    <Form.Label>First Name</Form.Label>
                                </Col>
                                <Col sm={8}>
                                    <Form.Control type="input" placeholder="First Name" name="firstName" onChange={this.handleChange} />
                                </Col>
                            </Row>
                        </Col>
                        <Col sm={6}>                           
                            <Row>
                                <Col sm={4}>
                                    <Form.Label>Last Name</Form.Label>
                                </Col>
                                <Col sm={8}>
                                    <Form.Control type="input" placeholder="Last Name" name="lastName" onChange={this.handleChange} />
                                </Col>
                            </Row>
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row} controlId="address">
                        <Col sm={3}>
                            <Row>
                                <Col sm={4}>
                                    <Form.Label>Street</Form.Label>
                                </Col>
                                <Col sm={8}>
                                    <Form.Control type="input" placeholder="Street" name="street" onChange={this.handleChange} />
                                </Col>
                            </Row>
                        </Col>
                        <Col sm={3}>
                            <Row>
                                <Col sm={3}>
                                    <Form.Label>City</Form.Label>
                                </Col>
                                <Col sm={9}>
                                    <Form.Control type="input" placeholder="City" name="city" onChange={this.handleChange} />
                                </Col>
                            </Row>
                        </Col>
                        <Col sm={3}>
                            <Row>
                                <Col sm={4}>
                                    <Form.Label column={2}>Province</Form.Label>
                                </Col>
                                <Col sm={8}>
                                    <Form.Control type="input" placeholder="province" name="province" onChange={this.handleChange} />
                                </Col>
                            </Row>
                        </Col>
                        <Col sm={3}>
                            <Row>
                                <Col sm={4}>
                                    <Form.Label column={2}>Post Code</Form.Label>
                                </Col>
                                <Col sm={8}>
                                    <Form.Control type="input" placeholder="Post Code" name="postCode" onChange={this.handleChange} />
                                </Col>
                            </Row>
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row} controlId="phoneNumber">
                        <Form.Label column={2}>Phone Number</Form.Label>
                        <Col sm={10}>
                            <Form.Control type="input" placeholder="Phone Number" name="phoneNumber" onChange={this.handleChange} />
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row} controlId="adminInfo">
                        <Col sm={{ span: 10, offset: 2 }}>
                            <Button type="submit">Sign in</Button>
                        </Col>
                    </Form.Group>
                </Form>
            </div>
        );
    }
});