import React, { Component } from 'react';

export class SelectOptions extends Component {
    constructor(props) {
        super(props);
        this.state = {
            options: [],
            isLoading: false,
            selected: this.props.selected
        };
        this.handleSelectedChange = this.handleSelectedChange.bind(this);
        this.setState({
            isLoading: true
        });
    }

    handleSelectedChange(event) {
        event.preventDefault();
        this.setState({ selected: event.target.value });
        this.props.onSelectedListChange(event.target.value);
    }

    render() {
        const selectedID = "sel" + this.state.selected.toString();
        return (
            <div className="form-group">
                <select className="form-control" id={selectedID} value={this.state.selected} disabled={this.props.disabled} onChange={this.handleSelectedChange} >
                    {
                        this.props.options.map(x => {
                            return (
                                <option value={x}>{x}</option>
                            );
                        })
                    }
                </select>
            </div>
        );
    }
}
