import React, { Component } from 'react';
import { Dropdown, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';


export class DropdownButton extends Component {
    constructor(props) {
        super(props); 
    }

    render() {

        if (this.props.blinks.length === 1) {
            return (
                <Link to={this.props.blinks[0].link} action={this.props.blinks[0].action}>
                    <Button variant="primary" size="sm" className="float-right mb-3">{this.props.blinks[0].text}</Button>
                </Link>
            );
        } else {

            return (
                <Dropdown>
                    <Dropdown.Toggle variant="success" id="dropdown-basic">
                        Options
                </Dropdown.Toggle>
                    <Dropdown.Menu>
                        {
                            this.props.blinks.map(bl => {
                                return (
                                    <Dropdown.Item href={bl.link} action={bl.action} pageNum={bl.pageNum} >{bl.text}</Dropdown.Item>
                                );
                            })
                        }
                    </Dropdown.Menu>
                </Dropdown>
            );
        }
    }
}