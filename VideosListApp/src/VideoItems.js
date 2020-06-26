import React, { Component } from 'react'

class VideoItems extends Component {
  renderVideo = item => {
    return (
      <tbody key={item.id}>
        <tr>
          <td>{item.name}</td>
          <td>{item.duration}</td>
          <td>{item.genre}</td>
          <td>{item.directedBy}</td>
          <td><input value="Delete" type="button" className="btn btn-danger" onClick={() => this.props.deleteItem(item.id)} /> </td>
          <td><input value="Edit" type="button" className="btn btn-info" onClick={() => this.props.editItem(item.id)} /></td>
        </tr>
      </tbody>
    )
  }
  render() {
    const listItems = this.props.entries.map(this.renderVideo)
    return <table className="table table-striped table-dark">
      <thead>
        <tr>
          <th>Name</th>
          <th>Duration</th>
          <th>Genre</th>
          <th>Directed By</th>
          <th></th>
          <th></th>
        </tr>
      </thead>
      {listItems}
    </table>
  }
}
export default VideoItems