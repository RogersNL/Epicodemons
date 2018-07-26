$(document).ready(function(){
  $("form#fightSubmit").click(function(event){
    event.preventDefault();
    $(".menu").hide();
    $(".attackBar").toggle();
  });
  var newWidth = $(".new-width").val();
  $(".player-move5").on('click',function(){
    $(".enemySprite").addClass('animated shake').one("webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend",
    function() {
      $(".enemy-bar-initial").hide();
      $(".player-move5").hide();
      $(".enemy-bar").fadeIn();
      $(".player-second").first().show();
    });
  });

  $(".player-second").click(function() {
    $(this).hide();
    $(this).next().show();
  });
});
