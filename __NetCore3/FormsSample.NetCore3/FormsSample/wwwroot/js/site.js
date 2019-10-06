function handleResult( data ) {

	let inner = '<h2>Data from Javascript</h2>' + '<span>' + data.lastName + '</span> <span>' + data.firstName + '</span>';
	$( '#resultDiv' ).html( inner );

}