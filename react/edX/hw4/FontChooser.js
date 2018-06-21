class FontChooser extends React.Component {

    constructor(props) {
		super(props);
		var initProps = this.enforceDefaults(props);
		this.state = { initProps: initProps,
						min: initProps.min,
						max: initProps.max,
						size: initProps.size,
						bold: props.bold == 'true' ? true : false,
						text: 'fooled ya',
						showCtrls: false
		};

	}

	toggleCtrls() {
		this.setState( { showCtrls: !this.state.showCtrls });
	}
	
	enforceDefaults(props) {
		var newProps = { min: parseInt(props.min),
			max: parseInt(props.max),
			size: parseInt(props.size)
		};
		if (newProps.min < 1)
			newProps.min = 1;

		if (newProps.min > newProps.max)
			newProps.max = newProps.min;

		if (newProps.size < newProps.min)
			newProps.size = newProps.min;

		if (newProps.size > newProps.max)
			newProps.size = newProps.max;

		return newProps;
	};

	toggleBold() {
		this.setState( { bold: !this.state.bold });
	}

	incrementSize() {
		if (this.state.max > this.state.size)
			this.setState( { size: this.state.size + 1 } );
	}

	decrementSize() {
		if (this.state.min < this.state.size)
			this.setState( { size: this.state.size - 1 } );
	}

	resetSize() {
		this.setState( { size: this.state.initProps.size } );
	}

    render() {
		var fontWt = this.state.bold ? 'bold' : 'normal';
		var sizeColor = (this.state.size == this.state.min) || (this.state.size == this.state.max) ? 'red' : 'black';

	return(
	       <div>
	       <input type="checkbox" id="boldCheckbox" hidden={!this.state.showCtrls} checked={this.state.bold} onChange={ this.toggleBold.bind(this) }/>
	       <button id="decreaseButton" hidden={!this.state.showCtrls} onClick={ this.decrementSize.bind(this)}>-</button>
	       <span id="fontSizeSpan" hidden={!this.state.showCtrls} style={{color: sizeColor}} onDoubleClick={this.resetSize.bind(this)}>{this.state.size}</span>
	       <button id="increaseButton" hidden={!this.state.showCtrls} onClick={ this.incrementSize.bind(this)}>+</button>
	       <span id="textSpan" style={{fontWeight: fontWt, fontSize: this.state.size + 'pt'}} onClick={this.toggleCtrls.bind(this)}>{this.props.text}</span>
	       </div>
	);
    }
}

