import React, {Component} from 'react';
import {Table} from 'react-bootstrap';

export class News extends Component{

    constructor(props){
        super(props);
        this.state = {news:[]}
    }

    refreshList(){
        fetch(process.env.REACT_APP_API + 'news')
        .then(response => response.json())
        .then(data => {
            this.setState({news: data});
        })
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }

    render(){
        const {news} = this.state;

        return(
            <div>
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Title</th>
                            <th>Short Description</th>
                            <th>Author</th>
                            <th>Theme</th>
                            <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {news.map(newsElement =>
                            <tr key={newsElement.Id}>
                                <td>{newsElement.Id}</td>
                                <td>{newsElement.Title}</td>
                                <td>{newsElement.ShortDesc}</td>
                                <td>{newsElement.Author.Name}</td>
                                <td>{newsElement.Theme.Name}</td>
                                <td>Edit / Delete</td>
                            </tr>)}
                    </tbody>
                </Table>
            </div>
        )
    }
}