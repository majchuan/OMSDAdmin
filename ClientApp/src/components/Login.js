import React, { Component } from 'react';
import { Form, Button, Row, Col } from 'react-bootstrap';
import { withRouter, Link } from 'react-router-dom';
import { AuthService } from '../service/AuthService';


export default withRouter(class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: "",
            password: "",
            loginFailed: false,
            loginInProgress: false
        };
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        let email = this.state.email;
        let password = this.state.password;

        let data = {
            userId: 0,
            email: email,
            userFirstName: "",
            userLastName: "",
            password: password,
            token: "",
            message: "",
            address : "",
            province :"",
            city : "",
            postCode : "",
            phoneNumber : ""
        };
        this.setState({
            email: email,
            password: password,
            loginFailed: false,
            loginInProgress: true
        });
        if (this.validateForm(email, password)) {
            const api = "api/User/Authenticate";
            fetch(api, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(data)
            }).then(response => {
                if (response.status != 200){
                    this.setState({
                        email: email,
                        password: password,
                        loginFailed: true,
                        loginInProgress: false
                    });
                }
                return response.json();
            }).then(responseData => {
                data = {
                    userId: responseData.userId,
                    email: responseData.email,
                    userFirstName: responseData.userFirstName,
                    userLastName: responseData.userLastName,
                    password: responseData.password,
                    token: responseData.token,
                    message: responseData.message
                };
                if (data.token.length > 0 && data.password.length === 0) {
                    AuthService.setAuthUser(JSON.stringify(data));
                    this.props.history.push("/home");
                } else {
                    // this.props.history.push("/login");
                    this.setState({
                        email: email,
                        password: password,
                        loginFailed: true,
                        loginInProgress: false
                    });
                }
            }).catch(err => console.log(err));



        } else {
            this.setState({
                email: email,
                password: password,
                loginFailed: true,
                loginInProgress: false
            });
        }
    }

    validateForm(email, password) {
        let regex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

        return regex.test(String(email).toLowerCase()) && String(password).length > 0;
    }

    handleChange(event) {
        event.preventDefault();
        switch (event.target.name) {
            case "email":
                this.setState({ email: event.target.value });
                break;
            case "password":
                this.setState({ password: event.target.value });
                break;
        }
    }

    render() {
        return (
            <div className="Container">
                <div className="Login">
                    <Form onSubmit={this.handleSubmit} style={{width:"400px"}}>
                        <Form.Group controlId="email">
                            <Form.Label>Email:</Form.Label>
                            <Form.Control autoFocus type="email" value={this.state.email} onChange={this.handleChange} name="email" />
                        </Form.Group>
                        <Form.Group controlId="passowrd">
                            <Form.Label>Password:</Form.Label>
                            <Form.Control autoFocus type="password" value={this.state.password} onChange={this.handleChange} name="password" />
                        </Form.Group>
                        <Form.Group as={Row} controlId="Login">
                            <Col sm={6} >
                                <Button block size="sm" type="submit"> Login </Button>
                            </Col>
                            <Col sm={6}>
                                <div style={{display: this.state.loginFailed ? 'inline' : 'none' }}>
                                    login failed. incorrect username or passowrd.
                                </div>
                                <div style={{display: this.state.loginInProgress ? 'inline' : 'none' }}>
                                    logining in... please wait....
                                </div>
                            </Col>
                        </Form.Group>
                    </Form>
                </div>
            </div>
        );
    }
});