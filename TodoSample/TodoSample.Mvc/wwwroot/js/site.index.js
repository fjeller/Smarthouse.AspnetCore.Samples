class IndexPageManager {

	constructor() {
		this._initialize();
	}

	_initialize() {

		let that = this;

		let buttons = $( '[data-id]' );
		if ( buttons.Length == 0) {
			return;
		}

		buttons.each(function() {
			let id = $( this ).data( 'id' );
			$(this).on('click',
				function ( e ) {
					e.preventDefault();
					$( '#todo-table' ).load( '/index?handler=Toggle&id=' + id, function () {
						that._initialize();
					});
				});
		});
	}
}