import React, { Component } from 'react';
import { Row, Col, Form, FormGroup, FormControl, FormLabel, Button, FormCheck, Alert, FormText } from 'react-bootstrap';
import { withRouter} from 'react-router-dom';
import { DropdownButton } from './DropdownButton';
import { AuthService } from '../service/AuthService';
import { ValidateClinic } from '../service/ValidateClinic';
import Message from './Message';
import { SelectOptions } from './SelectOptions';

export default withRouter(class Clinic extends Component {

    constructor(props) {
        super(props);
        this.state = {
            clinic: {
                name: "",
                phone1: "",
                phone2: "",
                physicalAddressLine1:"",
                physicalAddressLine2:'',
                city:"",
                postCode:"",
                physicalPostCode:"",
                email1:"",
                email2: "",
                primaryEmail:"",
                acceptNew:"",               
                longitude:"",              
                latitude:"",               
                serviceType:"",             
                fax:"",               
                website:"",              
                websiteFrench:""  ,          
                mailingAddressLine1:"" ,             
                mailingAddressLine2:"",               
                clinicAdminEmail:"",             
                communityAreas:"",              
                description:"",             
                descriptionFrench:"",              
                businessNotes:"",        
                businessNotesFrench: "",
                clinicHours:[],
                cityNames:[]
            },
            isEdit: false,
            isAdd: false,
            isLoading: false,
            clinicError: {
                hasError: false,
                message :""
            }
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleBackButton = this.handleBackButton.bind(this);
        this.handleSelectListChange = this.handleSelectListChange.bind(this);

        if (AuthService.isAuth() === false) {
            this.props.history.push('/login');
        }

        //const clinicId = this.props.match.params.id;
        //if (clinicId !== null && this.props.match.params.action !== "add") {
        //    const clinicIsEdit = (this.props.match.params.action === 'view' || this.props.match.params.action === 'delete') ? true : false;
        //    const API = '/api/Home/GetClinic/';
        //    fetch(API + clinicId, {
        //        method: "GET",
        //        headers: {
        //            "content-type": "application/json",
        //            "authorization": "Bearer " + AuthService.token()
        //        }
        //    })
        //        .then(response => {
        //            if (response.status === 401) {
        //                AuthService.logout();
        //                //this.props.history.push('/login');
        //            } else {
        //                return response.json();
        //            }
        //        })
        //        .then(data => {
        //            this.setState({ clinic: data, isEdit: clinicIsEdit }, () => {
        //                this.setState({
        //                    isLoading : true
        //                });
        //            });
        //        }).catch(exception => console.log(exception));
            
        //}
    }

    componentDidMount() {
        const clinicId = this.props.match.params.id;
        const clinicIsAdd = (this.props.match.params.action=="add") ? false : true;
        if (clinicId !== null && this.props.match.params.action !== "add") {
            const clinicIsEdit = (this.props.match.params.action === 'view' || this.props.match.params.action === 'delete') ? true : false;
            const API = '/api/Home/GetClinic/';
            fetch(API + clinicId, {
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
                        return response.json();
                    }
                })
                .then(data => {
                    console.log("DEBUG_MESSAGE: clinic: "+JSON.stringify(data));
                    this.setState({ clinic: data, isEdit: clinicIsEdit , isAdd: clinicIsAdd}, () => {
                        this.setState({
                            isLoading: true
                        });
                    });
                }).catch(exception => console.log(exception));
                

        }
    }

    handleSelectListChange(selectedValue,aClinicAttribute) {        
        var aClinic = {};

        switch (aClinicAttribute) {
            case 'primaryEmail':
                aClinic = this.state.clinic;
                aClinic.isEmail1Primary = selectedValue;
                break;
            case 'acceptNew':
                aClinic = this.state.clinic;
                aClinic.acceptingNew = selectedValue;
                break;
            default:
                aClinic = this.state.clinic;
                break;
        }
        this.setState({ clinic: aClinic });
    }

    handleChange(event){
        event.preventDefault();
        var aClinic = {};

        switch (event.target.name) {
            case 'name':
                aClinic = this.state.clinic;
                aClinic.name = event.target.value;
                break;
            case 'phone1':
                aClinic = this.state.clinic;
                aClinic.phone1 = event.target.value;
                break;
            case 'phone2':
                aClinic = this.state.clinic;
                aClinic.phone2 = event.target.value;
                break;
            case 'physicalAddressLine1':
                aClinic = this.state.clinic;
                aClinic.physicalAddressLine1 = event.target.value;
                break;
            case 'physicalAddressLine2':
                aClinic = this.state.clinic;
                aClinic.physicalAddressLine2 = event.target.value;
                break;
            case 'city':
                aClinic = this.state.clinic;
                aClinic.physicalCity = event.target.value;
                break;
            case 'postCode':
                aClinic = this.state.clinic;
                aClinic.physicalPostCode = event.target.value;
                aClinic.postCode = event.target.value;
                break;
            case 'email1':
                aClinic = this.state.clinic;
                aClinic.email1 = event.target.value;
                break;
            case 'email2':
                aClinic = this.state.clinic;
                aClinic.email2 = event.target.value;
                break;
            // case 'primaryEmail':
            //     aClinic = this.state.clinic;
            //     aClinic.primaryEmail = event.target.value;
            //     break;
            // case 'acceptNew':
            //     aClinic = this.state.clinic;
            //     aClinic.acceptNew = event.target.value;
            //     break;
            case 'longitude':
                aClinic = this.state.clinic;
                aClinic.longitude = event.target.value;
                break;
            case 'latitude':
                aClinic = this.state.clinic;
                aClinic.latitude = event.target.value;
                break;
            case 'serviceType':
                aClinic = this.state.clinic;
                aClinic.serviceType = event.target.value;
                break;
            case 'fax':
                aClinic = this.state.clinic;
                aClinic.fax = event.target.value;
                break;
            case 'website':
                aClinic = this.state.clinic;
                aClinic.website = event.target.value;
                break;
            case 'websiteFrench':
                aClinic = this.state.clinic;
                aClinic.websiteFrench = event.target.value;
                break;
            case 'mailingAddressLine1':
                aClinic = this.state.clinic;
                aClinic.mailingAddressLine1 = event.target.value;
                break;
            case 'mailingAddressLine2':
                aClinic = this.state.clinic;
                aClinic.mailingAddressLine2 = event.target.value;
                break;
            case 'clinicAdminEmail':
                aClinic = this.state.clinic;
                aClinic.clinicAdminEmail = event.target.value;
                break;
            case 'communityAreas':
                aClinic = this.state.clinic;
                aClinic.communityAndAreasServed = event.target.value;
                break;
            case 'description':
                aClinic = this.state.clinic;
                aClinic.description = event.target.value;
                break;
            case 'descriptionFrench':
                aClinic = this.state.clinic;
                aClinic.descriptionFrench = event.target.value;
                break;
            case 'businessNotes':
                aClinic = this.state.clinic;
                aClinic.hoursOfBusinessNotes = event.target.value;
                break;
            case 'businessNotesFrench':
                aClinic = this.state.clinic;
                aClinic.hoursOfBusinessNotesForFrench = event.target.value;
                break;
            default:
                aClinic = this.state.clinic;
                break;
        }
        this.setState({ clinic: aClinic });
    }

    handleSubmit(event) {
        event.preventDefault();

        if (this.validateClinic().hasError === false) {
            switch (this.props.match.params.action) {
                case 'edit':
                    fetch('/api/Home/UpdateClinic', {
                        method: 'PUT',
                        body: JSON.stringify(this.state.clinic),
                        headers: {
                            'content-type': 'application/json',
                            "authorization": "Bearer " + AuthService.token()
                        }
                    }).then(response => {
                        if (response.status === 200) {
                            
                            return response.json();
                        }
                    }).then(data => {                 
                        let clinicError = {hasError : false , message :""};
                        if (data.clinicId == -1){
                            clinicError.hasError = true;
                            clinicError.message = "The clinic does not exist.";
                            this.setState({ clinicError: clinicError })
                            return clinicError;
                        }
                        if ((data.physicalCity == "-1")&&(data.serviceType == "-1"))
                        {
                            clinicError.hasError = true;
                            clinicError.message = "The city and service type you entered does not exist."
                                                + " Try adding new city & service type or correct your spelling.";
                            this.setState({ clinicError: clinicError })
                            return clinicError;
                        }
                        if (data.physicalCity == "-1"){
                            clinicError.hasError = true;
                            clinicError.message = "The city you entered does not exist. "
                                                +" Try adding new city or correct your spelling.";
                            this.setState({ clinicError: clinicError })
                            return clinicError;
                        }
                        if (data.serviceType == "-1"){
                            clinicError.hasError = true;
                            clinicError.message = "The service type you entered does not exist."
                                                +" Try adding new service type or correct your spelling.";
                            this.setState({ clinicError: clinicError })
                            return clinicError;
                        }
                        this.props.history.push('/home');

                    }).catch(
                        err => console.log(err)
                    );
                    break;
                case 'delete':
                    fetch('/api/Home/DeleteClinic/' + this.state.clinic.clinicId, {
                        method: 'DELETE',
                        headers: {
                            'content-type': 'application/json',
                            "authorization": "Bearer " + AuthService.token()
                        }
                    }).then(response => {
                        if (response.status === 200) {                            
                            this.props.history.push('/home');
                        }
                    }).catch(err => console.log(err));
                    break;
                case 'add':
                    fetch('/api/Home/AddClinic', {
                        method: 'POST',
                        body: JSON.stringify(this.state.clinic),
                        headers: {
                            'content-type': 'application/json',
                            "authorization": "Bearer " + AuthService.token()
                        }
                    }).then(response => {
                        if (response.status === 200) {
                            return response.json();
                        }

                    }).then(data => {
                        let clinicError = {hasError : false , message :""};
                        if ((data.physicalCity == "-1")&&(data.serviceType == "-1"))
                        {
                            clinicError.hasError = true;
                            clinicError.message = "The city and service type you entered does not exist."
                                                + " Try adding new city & service type or correct your spelling.";
                            this.setState({ clinicError: clinicError })
                            return clinicError;
                        }
                        if (data.physicalCity == "-1"){
                            clinicError.hasError = true;
                            clinicError.message = "The city you entered does not exist. "
                                                +" Try adding new city or correct your spelling.";
                            this.setState({ clinicError: clinicError })
                            return clinicError;
                        }
                        if (data.serviceType == "-1"){
                            clinicError.hasError = true;
                            clinicError.message = "The service type you entered does not exist."
                                                +" Try adding new service type or correct your spelling.";
                            this.setState({ clinicError: clinicError })
                            return clinicError;
                        }
                        this.props.history.push('/home');
                    }).catch(
                        err => console.log(err)
                    );
                    break;
            }
        }


    }

    handleBackButton(event) {
        event.preventDefault();
        const activePage = this.props.match.params.page;

        if (activePage === undefined) {
            this.props.history.push('/home');
        } else {
            this.props.history.push('/home/' + activePage);
        }
    }

    validateClinic() {
        let emailError = ValidateClinic.validateEmail(this.state.clinic.email1);
        let postCodeError = ValidateClinic.validatePostCode(this.state.clinic.physicalPostCode);
        let phoneError = ValidateClinic.validatePhone(this.state.clinic.phone1);
        if (this.props.match.params.action !== "add"){
            emailError.hasError = false;
            phoneError.hasError = false;
        }
        let clinicError = {hasError : false , message :""};

        if (phoneError.hasError || emailError.hasError || postCodeError.hasError) {
            clinicError.hasError = true;
            if (phoneError.message.length > 0) {
                clinicError.message = phoneError.message;
            }
            if (emailError.message.length > 0) {
                clinicError.message = clinicError.message + "," + emailError.message;
            }
            if (postCodeError.message.length > 0) {
                clinicError.message = clinicError.message + "," + postCodeError.message;
            }
        }
        if (this.props.match.params.action === "delete"){
            clinicError.hasError = false;
        }
        this.setState({ clinicError: clinicError });
        return clinicError ;

    }

    render() {

        if (this.state.isLoading === false && this.props.match.params.action !== "add") {
            return (<p><em>Loading...</em></p>);
        } else {
            let style = {};
            let clinicHourStyle = {};
            let blinks_Option_Button = [];
            const activePage = this.props.match.params.page;
            switch (this.props.match.params.action) {
                case "view":
                    if (this.state.clinic.clinicHours.length > 0) {
                        blinks_Option_Button.push(
                            { action: "View", text: "View Clinic Hour", link: "/clinichour/View/"+ activePage+'/' + this.state.clinic.clinicId}
                        );
                    } else {
                        blinks_Option_Button.push(
                            { action: "Add", text: "Add Clinic Hour", link: "/clinichour/Add/" + activePage+'/' + this.state.clinic.clinicId  }
                        );
                    }
                    clinicHourStyle.display = 'inline';
                    style.display = 'none';
                    break;
                case "edit":
                    if (this.state.clinic.clinicHours.length > 0) {
                        blinks_Option_Button.push(
                            { action: "Edit", text: "Edit Clinic Hour", link: "/clinichour/Edit/" + activePage + '/'+ this.state.clinic.clinicId},
                            { action: "Delete", text: "Delete clinic hour", link: "/clinichour/Delete/" + activePage + '/' + this.state.clinic.clinicId}
                        );
                    } else {
                        blinks_Option_Button.push(
                            { action: "Add", text: "Add Clinic Hour", link: "/clinichour/Add/" + activePage + '/' + this.state.clinic.clinicId }
                        );
                    }
                    clinicHourStyle.display = 'inline';
                    style.display = 'block';
                    break;
                case "add":
                    blinks_Option_Button.push(
                        { action: "Add", text: "Add Clinic Hour", link: "/clinichour/Add/" + activePage + '/' + this.state.clinic.clinicId  }
                    );
                    clinicHourStyle.display = 'none';
                    style.display = 'block';
                    break;
                case "delete":
                    blinks_Option_Button.push(
                        { action: "Delete", text: "Delete Clinic Hour", link: "/clinichour/Delete/" + activePage + '/' + this.state.clinic.clinicId }
                    );
                    clinicHourStyle.display = 'inline';
                    style.display = 'block';
                    break;
    
            }
    
            if (this.state.clinicError.hasError) {
                return (
                    <Message message={this.state.clinicError.message} />
                    );
            }
    
            return (
                <div>
                    <div>
                        <Row>
                            <Col sm={12}>
                                <Button type="button" className="float-right mb-3" onClick={this.handleBackButton}>Back</Button>
                            </Col>
                        </Row>
                    </div>
                    <div style={{display: this.state.isAdd ? 'inline' : 'none' }}>
                        <Row>
                            <Col sm={12}>
                                Clinic ID: {this.state.clinic.clinicId}
                            </Col>
                        </Row>
                        <Row>
                            <Col sm={12}>
                                Date Created: {this.state.clinic.datecreated}
                            </Col>
                        </Row>
                        <Row>
                            <Col sm={12}>
                                Date Activated: {this.state.clinic.dateActivated}
                            </Col>
                        </Row>
                        <Row>
                            <Col sm={12}>
                                Date Modified: {this.state.clinic.dateModified}
                            </Col>
                        </Row>
                    </div>
                    <div>
                    <Form onSubmit={this.handleSubmit}>
                            <FormGroup as={Row}>
                                <FormLabel column sm={4} className="text-right">
                                Clinic Name
                                <font color="red" style={{display: this.state.isEdit ? 'none' : 'inline' }} >*</font>
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='input' type='text' value={this.state.clinic.name} name="name" onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                            <FormGroup as={Row}>
                                <FormLabel column sm={4} className="text-right">
                                Clinic Phone 1
                                <font color="red" style={{display: this.state.isEdit ? 'none' : 'inline' }} >*</font>
                            </FormLabel>
                            <Col sm={8}>
                            <FormControl readOnly={this.state.isEdit} as='input' type='text' 
                                    value={this.state.clinic.phone1} 
                                    placeholder={ this.state.isEdit ? this.state.clinic.phone1 : 'xxx-xxx-xxxx or xxxxxxxxxx' }
                                    name="phone1"
                                    onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Clinic Phone 2
                            </FormLabel>
                            <Col sm={8}>
                            <FormControl readOnly={this.state.isEdit} as='input' type='text' value={this.state.clinic.phone2}
                                    value={this.state.clinic.phone2}
                                    name='phone2'
                                    onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Clinic Address 1
                                <font color="red" style={{display: this.state.isEdit ? 'none' : 'inline' }} >*</font>
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='input' type='text' value={this.state.clinic.physicalAddressLine1}
                                    name='physicalAddressLine1' onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Clinic Address 2
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='input' type='text' value={this.state.clinic.physicalAddressLine2}
                                    name='physicalAddressLine2' onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                City
                                <font color="red" style={{display: this.state.isEdit ? 'none' : 'inline' }} >*</font>
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='input' type='text' value={this.state.clinic.physicalCity}
                                    name='city' onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Post Code
                                <font color="red" style={{display: this.state.isEdit ? 'none' : 'inline' }} >*</font>
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='input' type='text' value={this.state.clinic.physicalPostCode}
                                    name='postCode' onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Clinic Email 1
                                <font color="red" style={{display: this.state.isEdit ? 'none' : 'inline' }} >*</font>
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='input' type='text' value={this.state.clinic.email1}
                                    name='email1' onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Clinic Email 2
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='input' type='text' value={this.state.clinic.email2}
                                    name='email2' onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Primary Email
                            </FormLabel>
                            <Col sm={8}>
                                <div style={{width:"100px"}}>
                                    <SelectOptions 
                                        selected={this.state.isAdd ? this.state.clinic.isEmail1Primary : "No" } 
                                        options={["Yes","No"]} 
                                        disabled={this.state.isEdit} 
                                        onSelectedListChange={(v) => this.handleSelectListChange(v,"primaryEmail")}
                                    />
                                </div>
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Accepting New Patient
                            </FormLabel>
                            <Col sm={8}>
                                <div style={{width:"100px"}}>
                                    <SelectOptions 
                                        selected={this.state.isAdd ? this.state.clinic.acceptingNew : "No" } 
                                        options={["Yes","No"]} 
                                        disabled={this.state.isEdit} 
                                        onSelectedListChange={(v) => this.handleSelectListChange(v,"acceptNew")}
                                    />
                                </div>
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Clinic Longitude
                                <font color="red" style={{display: this.state.isEdit ? 'none' : 'inline' }} >*</font>
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='input' type='text' 
                                    value={this.state.clinic.longitude}
                                    placeholder={ this.state.isEdit ? this.state.clinic.longitude : '43.661806' }
                                    name='longitude' onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Clinic Latitude 
                                <font color="red" style={{display: this.state.isEdit ? 'none' : 'inline' }} >*</font>
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='input' type='text' 
                                    value={this.state.clinic.latitude}
                                    placeholder={ this.state.isEdit ? this.state.clinic.latitude : '-79.385681' }
                                    name='latitude' onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Clinic Service Type
                                <font color="red" style={{display: this.state.isEdit ? 'none' : 'inline' }} >*</font>
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='input' type='text' 
                                    value={this.state.clinic.serviceType}
                                    placeholder={ this.state.isEdit ? this.state.clinic.serviceType : 'Sexual Health Centre' }
                                    name='serviceType' onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Clinic Fax
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='input' type='text' value={this.state.clinic.fax}
                                    name='fax' onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Clinic Website
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='input' type='text' value={this.state.clinic.website}
                                    name='website' onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Clinic Mailing Address1
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='input' type='text' value={this.state.clinic.mailingAddressLine1}
                                    name='mailingAddressLine1' onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                                <FormLabel column sm={4} className="text-right">
                                Clinic Mailing Address2
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='input' type='text' value={this.state.clinic.mailingAddressLine2}
                                    name='mailingAddressLine2' onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Clinic Admin Email
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='input' type='text' value={this.state.clinic.clinicAdminEmail}
                                    name='clinicAdminEmail' onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Clinic website French
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='input' type='text' value={this.state.clinic.websiteFrench}
                                    name='websiteFrench' onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Clinic Community and Area Served
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='input' type='text' value={this.state.clinic.communityAndAreasServed}
                                    name='communityAreas' onChange={this.handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Description
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='textarea' type='text' value={this.state.clinic.description}
                                    name='description' onChange={this.handleChange} style={{height: "150px"}}/>
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                French Description
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='textarea' type='text' value={this.state.clinic.descriptionFrench}
                                    name='descriptionFrench' onChange={this.handleChange}  style={{height: "150px"}}/>
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                Hours of Business Notes
                            </FormLabel>
                            <Col sm={8}>
                                    <FormControl readOnly={this.state.isEdit} as='textarea' type='text' value={this.state.clinic.hoursOfBusinessNotes}
                                        name='businessNotes' onChange={this.handleChange}  style={{height: "150px"}} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                French Hours of Business Notes
                            </FormLabel>
                            <Col sm={8}>
                                <FormControl readOnly={this.state.isEdit} as='textarea' type='text' value={this.state.clinic.hoursOfBusinessNotesForFrench}
                                    name='businessNotesFrench' onChange={this.handleChange}  style={{height: "150px"}} />
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <FormLabel column sm={4} className="text-right">
                                <div style={clinicHourStyle}>
                                    Clinic Hours
                                </div>    
                            </FormLabel>
                            <Col sm={8}>
                                <div style={clinicHourStyle}>
                                    <DropdownButton blinks={blinks_Option_Button} />
                                </div>
                            </Col>
                        </FormGroup>
                        <FormGroup as={Row}>
                            <Col sm={{ span: 8, offset: 4 }}>
                                <div style={style}>
                                    <FormText column sm={4} className="text-left">
                                        <font color="red" size="+2">
                                            {this.props.match.params.action === 'delete' ? "WARNING: THE DELETION OF THIS CLINIC CAN NOT BE REVERTED." : ""}  
                                        </font>
                                    </FormText>
                                    <Button type='submit' variant={this.props.match.params.action === 'delete' ? "danger" : "primary"}>
                                        {this.props.match.params.action === 'delete' ? "Confirm Delete" : "Submit"}
                                    </Button>
                                </div>
                            </Col>
                        </FormGroup>
                    </Form>
                    </div>
                </div>
            );
        }



    }
});




