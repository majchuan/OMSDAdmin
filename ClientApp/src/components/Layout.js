import React, { Component } from 'react';
import { Col, Container, Row } from 'react-bootstrap';
import { NavMenu } from './NavMenu';
import AuthHeader from './AuthHeader';

export class Layout extends Component {
  displayName = Layout.name

  render() {
      return (
          <Container fluid>
            <Row>
              <Col sm={2}>
                <NavMenu />
              </Col>
                  <Col sm={10}>
                      <Row>
                          <Col sm={12}>
                              <AuthHeader/>
                          </Col>
                      </Row>
                      <Row>
                          <Col sm={12} >
                              {this.props.children}
                          </Col>
                      </Row>
              </Col>
              </Row>
          </Container>
    );
  }
}
