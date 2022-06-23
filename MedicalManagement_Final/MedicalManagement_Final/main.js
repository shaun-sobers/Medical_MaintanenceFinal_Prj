const options = {
	method: 'GET',
	headers: {
		'X-RapidAPI-Host': 'random-words5.p.rapidapi.com',
		'X-RapidAPI-Key': '6550bf9aeamshd7c9ef01c8e50e0p12c501jsn9f871695610c'
	}
};

fetch('https://random-words5.p.rapidapi.com/getMultipleRandom?count=5', options)
	.then(response => response.json())


	.then(response => {
		console.log(response);
		document.getElementById('<%= txtFname.ClientID %>').innerText = response;
	})
	


	.catch(err => console.error(err));