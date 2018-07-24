$(document).ready(function(){
$("form#fightSubmit").click(function(event){
  event.preventDefault();
  $(".menu").hide();
  $(".attackBar").toggle();

});
});
