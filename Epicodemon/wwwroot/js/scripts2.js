$(document).ready(function(){
  $("form#fightSubmit").click(function(event){
    event.preventDefault();
    $(".menu").hide();
    $(".attackBar").toggle();
  });
  var newWidth = $(".new-width").val();
  $(".player-move3").on('click',function(){
    $(".fighterSprite").addClass('animated shake').one("webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend",
    function() {
      $(".player-bar-initial").hide();
      $(".player-move3").hide();
      $(".player-bar").fadeIn();
      $(".computer-second").first().show();
    });
  });

  $(".computer-second").click(function() {
    $(this).hide();
    $(this).next().show();
  });
});
