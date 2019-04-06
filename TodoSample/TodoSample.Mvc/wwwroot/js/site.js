class IndexPageManager {

	constructor() {
		this._initialize();
	}

	_initialize() {

		let checkboxes = $( '[data-id]' );
		if (checkboxes.Length == 0) {
			return;
		}

		checkboxes.each(function() {
			let id = $( this ).data( 'id' );
			$(this).on('click',
				function() {
					$('#todo-table').load('/index?handler=Toggle&id=' + id);
				});
		});
	}
}
var indexPageManager;

$( function () {

	if ( $( '#pageIndex' ).Length > 0 ) {
		indexPageManager = new IndexPageManager();
	}

});
