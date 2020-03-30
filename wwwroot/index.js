function send_msg() {
   $("#success").hide();
   $("#failure").hide();
   axios.post('api/message', {
        message: $("#message").val()
    })
    .then(function (response) {
        if (response.status === 200)
        {
            $("#success").show();
        }
        else
        {
            $("#failure").show();
        }
    })
    .catch(function (error) {
        $("#failure").show();
    });
   
  }