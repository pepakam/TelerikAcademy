<?php get_header(); ?>

<div class="9u">
  <div id="content">
    <?php if( have_posts() ):
while( have_posts() ):
the_post();
?>
    <section>
      <div class="post clearfix">
        <?php get_template_part( 'content', 'index' ); ?>
      </div>
    </section>
    <?php endwhile;?>
    <?php project3_content_nav( 'nav-below' ); ?>
    <?php endif; ?>
  </div>
</div>
<?php get_sidebar('sidebar1');

get_footer(); ?>
