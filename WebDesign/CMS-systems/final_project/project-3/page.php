<?php
/**
 * @package WordPress
 * @subpackage project3
 */

get_header(); ?>

<div class="9u">
  <div id="content">
    <section>
      <div class="post clearfix page">
        <?php the_post(); ?>
        <?php get_template_part( 'content', 'page' ); ?>
        <?php comments_template(); ?>
      </div>
    </section>
  </div>
</div>
<?php get_sidebar('sidebar1');
get_footer(); ?>
