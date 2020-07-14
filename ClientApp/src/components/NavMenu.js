import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Nav, Navbar, NavItem, Container, Row } from 'react-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
      return (
          <div>
          <Navbar.Brand>
              <Link to={'/Home'}>OMSDAdmin</Link>
          </Navbar.Brand>
            <Nav defaultActiveKey="/" className="flex-column">
              <Nav.Link href="/home">Home</Nav.Link>
              {/* <Nav.Link eventKey="User" href="/user">User-Profile</Nav.Link> */}
              <Nav.Link eventKey="ServiceType" href="/servicetype">Service Types</Nav.Link>
              <Nav.Link eventKey="City" href="/city">Ontario Cities</Nav.Link>
              
            </Nav>
          </div>
    );
  }
}
