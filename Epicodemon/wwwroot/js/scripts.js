$(document).ready(function(){
  $("form#fightSubmit").click(function(event){
    event.preventDefault();
    $(".menu").hide();
    $(".attackBar").toggle();
  });
  $(".clickable").first().show();
  $(".clickable").click(function() {
    $(this).hide();
    $(this).next().show();
  });
  var $progressBar = $(".progress-bar").css('100%', 'width');
});
