$(document).ready(function(){
  $("form#fightSubmit").click(function(event){
    event.preventDefault();
    $(".menu").hide();
    $(".attackBar").toggle();

  });
  $(".message-0").show();

  $("#form-0").submit(function(event){
    event.preventDefault();
    var currentMessage = parseInt($("#formindex").val());
    var nextMessage = currentMessage + 1;
    $(".message-" + currentMessage).hide();
    $(".message-" + nextMessage).show();
    $("#form-" + nextMessage).submit(function(event){
      event.preventDefault();
      var currentMessage = $("#formindex").val();
      $(".message-" + currentMessage).hide();
      $(".message-" + nextMessage).show();
    });
  });
});
