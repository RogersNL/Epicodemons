$(document).ready(function(){
  $("form#fightSubmit").click(function(event){
    event.preventDefault();
    $(".menu").hide();
    $(".attackBar").toggle();
  });
  var newWidth = $(".new-width").val();
  $(".player-move1").on('click',function(){
    $(".enemySprite").addClass('animated shake').one("webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend",
    function() {
      $(".enemy-bar-initial").hide();
      $(".player-move1").hide();
      $(".enemy-bar").fadeIn();
      $(".player-first").first().show();
    });
  });

  $(".player-first").click(function() {
    $(this).hide();
    $(this).next().show();
  });
});
