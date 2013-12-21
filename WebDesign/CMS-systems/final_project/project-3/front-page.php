<?php get_header(); ?>

<div class="6u">
  <div id="content">
    <?php if (have_posts()) : ?>
    <?php while (have_posts()) : the_post(); ?>
    <section class="clearfix">
      <div class="post clearfix">
        <h2>
          <?php the_title(); ?>
        </h2>
        <div class="entry-details"><!-- entry-details -->
          <p><?php echo get_the_date(); ?>
            <?php _e( 'by', 'project3' ); ?>
            <?php the_author() ?>
            <?php comments_popup_link( __( '0 comments', 'project3' ), __( '1 Comment', 'project3' ), __( '% Comments', 'project3' ) ); ?>
          </p>
        </div>
        
        <!-- end entry-details -->
        <div> <a href="<?php the_permalink() ?>">
          <?php
                  if ( has_post_thumbnail() ) { 
                   the_post_thumbnail( array(300,250) ); ?>
          <?php } else { ?>
          <img src="<?php echo get_template_directory_uri(); ?>/images/javascript-ninja.png" class="img-alignleft" alt="ninja"/>
          <?php } ?>
          </a>
          <?php the_excerpt(); 
                ?>
        </div>
        <p class="button-style"><a href="<?php the_permalink() ?>">Read Full Article</a></p>
      </div>
    </section>
    <?php endwhile; ?>
    <?php project3_content_nav( 'nav-below' ); ?>
    <?php endif; ?>
  </div>
</div>
<?php get_sidebar('custom');
 get_sidebar('sidebar1');

 get_footer(); ?>
