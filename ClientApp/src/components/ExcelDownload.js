import React, { Component } from 'react';
import { Dropdown, Row, InputGroup, FormControl, Button, Col, Table, Pagination, ListGroup, PageItem } from 'react-bootstrap';
import { DropdownButton } from './DropdownButton';
import { AuthService } from '../service/AuthService';
import { withRouter } from 'react-router-dom';
import { Form, FormGroup, ControlLabel } from "react-bootstrap";
import FileSaver from 'file-saver';

export default withRouter(class ExcelDownload extends Component {
    constructor(props) {
        super(props);
        if (AuthService.isAuth() === false) {
            this.props.history.push('/login');
        }
    }

    componentDidMount() {

        fetch('api/Excel/Download2Async', {
            method: "GET",
            headers: {
                "content-type": "application/json",
                "authorization": "Bearer " + AuthService.token()
            }
        })
        .then(response => {
            if (response.status === 401) {
                AuthService.logout();
                this.props.history.push('/login');
            } else {                
                this.props.history.push('/home');
                return response.blob();
            }
        })
        .then(function(blob) {
            FileSaver.saveAs(blob, 'clinics.xlsx');            
        }).catch(err => console.log(err));

    }
    render() {
        return <h1>Downloading...</h1>
    }
});