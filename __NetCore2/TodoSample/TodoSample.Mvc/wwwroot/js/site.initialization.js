var indexPageManager;

$( function () {

	let pageindexLength = $('#pageIndex').length;

	if ( pageindexLength > 0 ) {
		indexPageManager = new IndexPageManager();
	}

});