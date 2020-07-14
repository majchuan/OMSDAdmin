import React, { Component } from 'react';

export class Pagination extends Component {
    constructor(props) {
        super(props);
        this.state = {
            page: {},
            isLoading: false
        };
        this.handlePaginationClick = this.handlePaginationClick.bind(this);

    }


    handlePaginationClick(event) {
        event.preventDefault();
        let aPageNumber = event.target.name;
        let aPageSize = this.props.page.pageSize;

        if (aPageNumber <= 0) {
            aPageNumber = 1;
        }
        if (aPageNumber > this.props.page.totalPages) {
            aPageNumber = this.props.page.totalPages;
        }

        let startIndex = (aPageNumber - 1) * aPageSize;
        let endIndex = startIndex + aPageSize - 1;
        if (endIndex > this.props.page.pageItems.length) {
            endIndex = startIndex + this.props.page.pageItems.length - 1;
        }
        const page = {
            pageSize: aPageSize,
            pageItems: this.props.page.pageItems,
            totalPages: this.props.page.totalPages,
            pageNumber: aPageNumber
        };
        this.setState({
            page: page
        }, () => {
                this.props.onClick(this.state.page);
            });

    }


    render() {

        let active = parseInt(this.props.page.pageNumber);
        let pageItems = [];
        let pageItem = {};
        for (let number = 1; number <= this.props.page.totalPages; number++) {
            if (number === active) {
                pageItem =(
                    <li className="page-item active">
                        <a className="page-link" href="#" onClick={this.handlePaginationClick} name={number} >{number}</a>
                    </li>);
            } else {
                pageItem = (
                    <li className="page-item">
                        <a className="page-link" href="#" onClick={this.handlePaginationClick} name={number} >{number}</a>
                    </li>);
            }
            pageItems.push(pageItem);
        }

        return (
            <nav aria-label="...">
                <ul className="pagination">
                    <li className="page-item">
                        <a className="page-link" href="#" tabIndex="-1" onClick={this.handlePaginationClick} name={parseInt(this.state.page.pageNumber) - 1} >Previous</a>
                    </li>
                    {pageItems}
                    <li className="page-item">
                        <a className="page-link" href="#" onClick={this.handlePaginationClick} name={parseInt(this.state.page.pageNumber) + 1} >Next</a>
                    </li>
                </ul>
            </nav>
            );
    }
}