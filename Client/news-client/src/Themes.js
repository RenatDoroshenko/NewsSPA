import React, {Component} from 'react';
import {Table} from 'react-bootstrap';

import {Button,ButtonToolbar} from 'react-bootstrap';
import {AddThemeModal} from './AddThemeModal';
import {EditThemeModal} from './EditThemeModal';

export class Themes extends Component{

    constructor(props){
        super(props);
        this.state = {themes:[], addModalShow: false, editModalShow: false}
    }

    refreshList(){
        fetch(process.env.REACT_APP_API + 'themes')
        .then(response => response.json())
        .then(data => {
            this.setState({themes: data});
        })
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }

    deleteTheme(id){
        if(window.confirm('Are you sure?')){
            fetch(process.env.REACT_APP_API+'themes/'+ id,{
                method:'DELETE',
                header:{
                    'Accept':'application/json',
                    'Content-Type':'application/json'
                }
            })
        }
    }

    render(){
        const {themes, id, name, shortDesc} = this.state;
        let addModalClose=()=>this.setState({addModalShow: false});
        let editModalClose=()=>this.setState({editModalShow: false});

        return(
            <div>
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Short Description</th>
                            <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {themes.map(newsElement =>
                            <tr key={newsElement.Id}>
                                <td>{newsElement.Id}</td>
                                <td>{newsElement.Name}</td>
                                <td>{newsElement.ShortDesc}</td>
                                <td>
                                    <ButtonToolbar>
                                        <Button className="mr-2" variant="info"
                                            onClick={()=>this.setState({editModalShow:true,
                                            id:newsElement.Id,name: newsElement.Name, shortDesc: newsElement.ShortDesc})}>
                                            Edit
                                        </Button>

                                        <Button className="mr-2" variant="danger"
                                            onClick={()=>this.deleteTheme(newsElement.Id)}>
                                            Delete
                                        </Button>

                                        <EditThemeModal show={this.state.editModalShow}
                                            onHide={editModalClose}
                                            id={id}
                                            name={name}
                                            shortDesc={shortDesc}/>

                                    </ButtonToolbar>
                                </td>
                            </tr>)}
                    </tbody>
                </Table>
                <ButtonToolbar>
                    <Button variant='primary'
                    onClick={()=>this.setState({addModalShow:true})}>
                    Add Theme</Button>

                    <AddThemeModal show={this.state.addModalShow}
                    onHide={addModalClose}/>
                </ButtonToolbar>
            </div>
        )
    }
}