import React, { Component } from 'react'
const ReactDOM = require('react-dom')

class VideoList extends Component {
    render() {
        return (
            <div className="videoListMain">
                <div className="header">
                    <form onSubmit={this.props.addItem}>
                        <div className="form-group row ">
                            <label htmlFor="name" className="col-md-1">Name</label>
                            <div className="col-md-11">
                                <input placeholder="Video name"
                                    ref={this.props.formElements.name}
                                    value={this.props.currentItem.name}
                                    onChange={this.props.onInputChange}
                                    name="name"
                                    className="form-control"
                                />
                            </div>
                        </div>

                        <div className="form-group row">
                            <label htmlFor="duration" className="col-md-1">Duration</label>
                            <div className="col-md-11">
                                <input placeholder="Duration"
                                    ref={this.props.formElements.duration}
                                    value={this.props.currentItem.duration}
                                    type="number"
                                    onChange={this.props.onInputChange}
                                    name="duration"
                                    className="form-control"
                                />
                            </div>
                        </div>

                        <div className="form-group row">
                            <label htmlFor="directedBy" className="col-md-1"> Directed By</label>
                            <div className="col-md-11">
                                <input placeholder="Directed By"
                                    ref={this.props.formElements.directedBy}
                                    value={this.props.currentItem.directedBy}
                                    onChange={this.props.onInputChange}
                                    name="directedBy"
                                    className="form-control"
                                />
                            </div>
                        </div>

                        <div className="form-group row">
                            <label htmlFor="genre" className="col-md-1"> Genre</label>
                            <div className="col-md-11">
                                <input placeholder="Genre"
                                    ref={this.props.formElements.genre}
                                    value={this.props.currentItem.genre}
                                    onChange={this.props.onInputChange}
                                    name="genre"
                                    className="form-control"
                                />
                            </div>
                        </div>
                        <button type="submit">Add Task</button>
                    </form>
                </div>
            </div>
        )
    }
}

export default VideoList