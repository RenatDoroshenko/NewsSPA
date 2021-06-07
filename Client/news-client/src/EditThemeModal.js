import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';

export class EditThemeModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'themes',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                Id: event.target.Id.value,
                Name: event.target.Name.value,
                ShortDesc:event.target.ShortDesc.value
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result.Name + ' was added successfully!');
        },
        (error)=>{
            alert('Failed');
        })
    }

    render(){
        return(
            <div className="container">

    <Modal {...this.props}
    size="lg"
    aria-labelledby="contained-modal-title-vcenter"
    centered
    >
        <Modal.Header clooseButton>
            <Modal.Title id="contained-modal-title-vcenter">
                Edit Theme
            </Modal.Title>
        </Modal.Header>

        <Modal.Body>
            <Row>
                <Col sm={6}>
                    <Form onSubmit={this.handleSubmit}>
                        <Form.Group controlId="Id">
                            <Form.Label>Id</Form.Label>
                            <Form.Control type="number" name="Id" required
                            disabled
                            defaultValue={this.props.id} 
                            placeholder="Id"/>
                        </Form.Group>

                        <Form.Group controlId="Name">
                            <Form.Label>Name</Form.Label>
                            <Form.Control type="text" name="Name" required 
                            defaultValue={this.props.name} 
                            placeholder="Name"/>
                        </Form.Group>

                        <Form.Group controlId="ShortDesc">
                            <Form.Label>Short Description</Form.Label>
                            <Form.Control type="text" name="ShortDesc" required 
                            defaultValue={this.props.shortDesc} 
                            placeholder="ShortDesc"/>
                        </Form.Group>


                        <Form.Group>
                            <Button variant="primary" type="submit">
                                Update Theme
                            </Button>
                        </Form.Group>
                    </Form>
                </Col>
            </Row>
        </Modal.Body>
        
        <Modal.Footer>
            <Button variant="danger" onClick={this.props.onHide}>Close</Button>
        </Modal.Footer>

    </Modal>

</div>
        );
    }
}