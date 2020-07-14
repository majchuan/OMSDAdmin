import React, { Component } from 'react';
import { Row, Col, Button } from 'react-bootstrap';
import { Link, withRouter, Redirect } from 'react-router-dom';
import { AuthService } from '../service/AuthService';

export default withRouter(class AuthHeader extends Component {
    constructor(props) {
        super(props);
        this.handleClick = this.handleClick.bind(this);

        if (AuthService.isAuth() === false) {
            this.props.history.push("/login");
        }
     
        
    }

    handleClick(event) {
        event.preventDefault();
        AuthService.logout();
        this.props.history.push("/login");
    }

    render() {
        const aUser = AuthService.user();

        const aUserName = aUser ? aUser.userFirstName + "," + aUser.userLastName : "";

        if (AuthService.isAuth() === false) {
            return (
                    <div/>
                );
        }
        return (
            <div>
                <Row>
                    <Col sm={6}>
                        {/* <Link to={"/userdetail/View/" + aUser.userId }> */}
                            Name : {aUserName}
                        {/* </Link> */}
                    </Col>
                    <Col sm={6}>
                        <Button variant="link" size="sm" onClick={this.handleClick}>Logout</Button>
                    </Col>
                </Row>
            </div>
        );
    }
});