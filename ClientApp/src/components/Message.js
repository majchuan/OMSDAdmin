import React, { Component } from 'react';
import { withRouter } from 'react-router-dom';
import { Row, Col } from 'react-bootstrap';

export default withRouter(class Message extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <Row>
                    <Col sm={12}>
                        <div>
                            <h1>Something Went Wrong</h1>
                            <p>The error: { this.props.message}</p>
                        </div>
                    </Col>
                </Row>
            </div>
        );
    }

});