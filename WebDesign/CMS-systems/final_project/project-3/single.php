<?php
/**
 * @package WordPress
 * @subpackage project3
 */

get_header(); ?>

<div class="9u">
  <div id="content">
    <section>
      <div class="post clearfix">
        <?php if ( have_posts() ) while ( have_posts() ) : the_post(); ?>
        <?php get_template_part( 'content', 'single' ); ?>
        <?php comments_template(); ?>
        <?php endwhile; // end of the loop. ?>
        <nav id="nav-below">
          <div class="nav-previous">
            <?php previous_post_link( '%link', '' . _x( '&laquo;  Previous Post', 'Previous post link', 'project3' ) . '' ); ?>
          </div>
          <div class="nav-next">
            <?php next_post_link( '%link', __('') . _x( 'Next Post &raquo;', 'Next post link', 'project3' ) . '' ); ?>
          </div>
        </nav>
      </div>
    </section>
  </div>
</div>
<?php get_sidebar('sidebar1');
get_footer(); ?>
