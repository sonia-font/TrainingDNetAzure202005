import React, { Component } from 'react'
import './App.css'
import VideoList from './VideoList'
import VideoItems from './VideoItems'
const uuidv1 = require('uuid/v1')
const urlApi = "https://netacademy.azurewebsites.net"; 
//"https://localhost:44332"; -local-
//"https://az-training-videos-api-je.azurewebsites.net"; -static en azure-

class App extends Component {

  constructor() {
    super()
    this.state = {
      currentItem: this.getClearItem(),
      items: [],
      editMode: false
    }
    this.formElements = {
      name: React.createRef(),
      duration: React.createRef()
    }
    this.getItems()
  }

  onInputChange = e => {
    const target = e.target;
    const value = target.type === 'checkbox' ? target.checked : target.value;
    const name = target.name;

    const newItem = this.state.currentItem
    newItem.id = newItem.id || uuidv1()
    newItem[name] = value;

    this.setState({
      currentItem: newItem
    })
  }

  getItems() {
    this.sendRequest('GET', '/api/videos', null, (response) => {
      this.setState({
        items: response
      })
    });
  }

  addItem = e => {
    e.preventDefault()
    var currentItem = this.state.currentItem
    if (currentItem.name !== '') {
      this.sendRequest(this.state.editMode ? 'PUT' : 'POST', '/api/videos', currentItem, (response) => {
        this.getItems();
        this.setState({
          editMode: false,
          currentItem: this.getClearItem()
        })
      });
    }
  }

  deleteItem = id => {
    this.sendRequest('DELETE', '/api/videos/' + id, null, (response) => {
      this.getItems();
    });
  }

  editItem = id => {
    this.sendRequest('GET', '/api/videos/' + id, null, (response) => {
      this.setState({
        currentItem: response,
        editMode: true
      })
    });
  }

  render() {
    return (
      <div className="App">
        <h1>Videos List</h1>
        <VideoList addItem={this.addItem}
          formElements={this.formElements}
          onInputChange={this.onInputChange}
          currentItem={this.state.currentItem}
        />
        <VideoItems entries={this.state.items} deleteItem={this.deleteItem} editItem={this.editItem} />
      </div>
    )
  }

  sendRequest(httpVerb, apiMethod, bodyContent, callbackMethod) {
    const options = {
      method: httpVerb,
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Methods": "DELETE, POST, GET, OPTIONS",
        "Access-Control-Allow-Headers": "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With"
      }
    };
    if (httpVerb != 'GET') { options.body = JSON.stringify(bodyContent); }

    fetch(urlApi + apiMethod, options)
      .then(response => {
        const contentType = response.headers.get("content-type");
        if (contentType && contentType.indexOf("application/json") !== -1) {
          if ((response.status === 200 || response.status === 201)) {
            return response ? response.json() : '';
          } else {
            throw new Error('Something went wrong on api server!');
          }
        } else {
          return response.text();
        }
      })
      .then(response => {
        callbackMethod(response);
      }).catch(error => {
        console.error(error);
      });
  }

  getClearItem() {
    return {
      id: null,
      name: '',
      duration: 0,
      directedBy: '',
      genre: ''
    }
  }
}

export default App
