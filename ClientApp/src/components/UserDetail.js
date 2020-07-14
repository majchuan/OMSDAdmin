import React, { Component } from "react";
import { Row, Col, Form, Button } from "react-bootstrap";
import { AuthService } from '../service/AuthService';
import { withRouter, Link } from 'react-router-dom';

export default withRouter(class UserDetails extends Component {
    constructor(props) {
        super(props);  
        this.state = {
            user: {
                userId: 0,
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
                token: "",
                userType: ""
            },
            isLoading: (new String(this.props.match.params.action).toUpperCase()) === "ADD" ? true : false,
            isEdit : false,
            isAdd: false
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleResponse = this.handleResponse.bind(this);
        this.handleEnableEditUser = this.handleEnableEditUser.bind(this);
        if (AuthService.isAuth) {
            const action = new String(this.props.match.params.action).toUpperCase();
            switch (action) {
                case "EDIT":
                    this.initEdit();
                    break;
                case "VIEW":
                    this.initEdit();
                    break;
                case "DELETE":
                    this.deleteUser();
                    break;
            }
        } else {
            this.props.history.push('/login');
        }


    }


    initEdit() {
        const api = "/api/User/GetUser/" + this.props.match.params.id;
        fetch(api, {
            method: "GET",
            headers: {
                "content-type": "application/json",
                "authorization": "Bearer " + AuthService.token()
            }
        }).then(response => {
            if (response.status === 401) {
                AuthService.authService.logout();
                this.props.history.push('/login');
            } else {
                return response.json();
            }
        }).then(data => {
            this.setState({
                user: {
                    userId: data.userId,
                    email: data.email,
                    password: data.password,
                    userFirstName: data.userFirstName,
                    userLastName: data.userLastName,
                    address: data.address,
                    city: data.city,
                    province: data.province,
                    postCode: data.postCode,
                    phoneNumber: data.phoneNumber,
                    message: data.message,
                    token: data.token,
                    userType: data.userType
                }
            }, () => {
                    this.setState({
                        isLoading:true 
                    });
            });
        }).catch(err => console.log(err));
    }

    deleteUser() {
        const api = "/api/User/DeleteUser/" + this.props.match.params.id;
        fetch(api, {
            method: "DELETE",
            headers: {
                "content-type": "application/json",
                "authorization": "Bearer " + AuthService.token()
            }
        }).then(response => {
            if (response.status === 401) {
                AuthService.authService.logout();
                this.props.history.push("/login");
            } else {
                return response.json();
            }
        }).catch(err => console.log(err));
    }

    handleSubmit(event) {
        event.preventDefault();
        const action = new String(this.props.action).toUpperCase();
        if (action === "EDIT" || this.state.isAdd) {
            const api = "api/User/UpdateUser";
            fetch(api, {
                method: "PUT",
                headers: {
                    "content-type": "application/json",
                    "authorization": "Bearer " + AuthService.token()
                },
                body: JSON.stringify(this.state.user)
            }).then(response => {
                if (response.status === 200) {
                    return response.json()
                }
            }).then(data => {
                this.setState({
                    user: {
                        userId: data.userId,
                        email: data.email,
                        password: data.password,
                        userFirstName: data.userFirstName,
                        userLastName: data.userLastName,
                        address: data.address,
                        city: data.city,
                        province: data.province,
                        postCode: data.postCode,
                        phoneNumber: data.phoneNumber,
                        message: data.message,
                        token: data.token,
                        userType: data.userType
                    }
                }, () => {
                        this.setState({
                            isLoading:true 
                        });
                });
                this.props.history.push('/userdetail/View/'+this.state.user.userId);
            }).catch(err => console.log(err));

        }else {
            const api = "api/User/Register";

            if (this.state.user.password.length > 0) {
                fetch(api, {
                    method: "POST",
                    headers: {
                        "content-type": "application/json",
                        "authorization": "Bearer " + AuthService.token()
                    },
                    body: JSON.stringify(this.state.user)
                }).then(response => {
                    if (response.status === 200) {
                        return response.json()
                    }
                }).then(data => {
                    this.setState({
                        user: {
                            userId: data.userId,
                            email: data.email,
                            password: data.password,
                            userFirstName: data.userFirstName,
                            userLastName: data.userLastName,
                            address: data.address,
                            city: data.city,
                            province: data.province,
                            postCode: data.postCode,
                            phoneNumber: data.phoneNumber,
                            message: data.message,
                            token: data.token,
                            userType: data.userType
                        }
                    }, () => {
                            this.setState({
                                isLoading:true 
                            });
                    });
                    this.props.history.push('/userdetail/View/'+this.state.user.userId);
                }).catch(err => console.log(err));
            }
        }
    }

    handleResponse(response) {
        switch (response) {
            case 200:                
                this.props.history.push('/userdetail/View/'+this.state.user.userId);
                break;
            case 401:
                AuthService.authService.logout();
                this.props.history.push("/login");
                break;
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

    handleEnableEditUser(event) {
        event.preventDefault();
        this.setState({ isEdit: true });
        this.setState({ isAdd: true });
    }

    render() {

        let disabled = false;
        let buttonText = "Update User";
        let addStyle = {};
        const LocalUser = JSON.parse(localStorage.getItem('user'));
        const url_userid = parseInt(this.props.match.params.id);
        const action = new String(this.props.match.params.action).toUpperCase();
        if (action === "VIEW") {
            disabled = true;
            addStyle.display = "inline";
        } else if (action === "ADD") {
            addStyle.display = "none";
            buttonText = "Create New User";
        }
        if (LocalUser.userId != url_userid){
            addStyle.display = "none";
        }

        if (this.state.isLoading === false) {
            return (<p><em>Loading...</em></p>);
        }

        if (this.state.isEdit === true) {
            disabled = false;
        }

        return (
            <div>
                <Row>
                    <Col sm={12}>
                        <div style={addStyle}>
                            <Button type="button" className="mb-3 float-left" onClick={this.handleEnableEditUser}>Edit User</Button>
                        </div>
                        <div>
                            <Link to={'/user/' + this.props.match.params.page}>
                                <Button type="button" className="ml-2 mr-2 mb-3 float-left">Back</Button>
                            </Link>
                        </div>
                    </Col>
                </Row>
                <Form onSubmit={this.handleSubmit}>
                    <Form.Group as={Row} controlId="email">
                        <Form.Label column={2}>Email</Form.Label>
                        <Col sm={10}>
                            <Form.Control type="email" placeholder="Email" name="email" onChange={this.handleChange} value={this.state.user.email} disabled={disabled} />
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row} controlId="password">
                        <Form.Label column={2}>Password</Form.Label>
                        <Col sm={10}>
                            <Form.Control type="password" placeholder="Password" name="password" onChange={this.handleChange} value={this.state.user.password} disabled={disabled}  />
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row} controlId="name">
                        <Col sm={6}>
                            <Row>
                                <Col sm={4}>
                                    <Form.Label>First Name</Form.Label>
                                </Col>
                                <Col sm={8}>
                                    <Form.Control type="input" placeholder="First Name" name="firstName" onChange={this.handleChange} value={this.state.user.userFirstName} disabled={disabled} />
                                </Col>
                            </Row>
                        </Col>
                        <Col sm={6}>
                            <Row>
                                <Col sm={4}>
                                    <Form.Label>Last Name</Form.Label>
                                </Col>
                                <Col sm={8}>
                                    <Form.Control type="input" placeholder="Last Name" name="lastName" onChange={this.handleChange} value={this.state.user.userLastName} disabled={disabled}  />
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
                                    <Form.Control type="input" placeholder="Street" name="street" onChange={this.handleChange} value={this.state.user.address} disabled={disabled}  />
                                </Col>
                            </Row>
                        </Col>
                        <Col sm={3}>
                            <Row>
                                <Col sm={3}>
                                    <Form.Label>City</Form.Label>
                                </Col>
                                <Col sm={9}>
                                    <Form.Control type="input" placeholder="City" name="city" onChange={this.handleChange} value={this.state.user.city} disabled={disabled}  />
                                </Col>
                            </Row>
                        </Col>
                        <Col sm={3}>
                            <Row>
                                <Col sm={4}>
                                    <Form.Label column={2}>Province</Form.Label>
                                </Col>
                                <Col sm={8}>
                                    <Form.Control type="input" placeholder="province" name="province" onChange={this.handleChange} value={this.state.user.province} disabled={disabled}  />
                                </Col>
                            </Row>
                        </Col>
                        <Col sm={3}>
                            <Row>
                                <Col sm={4}>
                                    <Form.Label column={2}>Post Code</Form.Label>
                                </Col>
                                <Col sm={8}>
                                    <Form.Control type="input" placeholder="Post Code" name="postCode" onChange={this.handleChange} value={this.state.user.postCode} disabled={disabled} />
                                </Col>
                            </Row>
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row} controlId="phoneNumber">
                        <Form.Label column={2}>Phone Number</Form.Label>
                        <Col sm={10}>
                            <Form.Control type="input" placeholder="Phone Number" name="phoneNumber" onChange={this.handleChange} value={this.state.user.phoneNumber} disabled={disabled} />
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row} controlId="adminInfo">
                        <Col sm={{ span: 10, offset: 2 }}>
                            <Button type="submit" disabled={disabled} >{buttonText}</Button>
                        </Col>
                    </Form.Group>
                </Form>
            </div>
        );
    }
});