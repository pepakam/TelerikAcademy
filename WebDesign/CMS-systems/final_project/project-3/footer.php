</div>
</div>
</div>

<div class="5grid-layout">
  <div class="row" id="footer-content">
    <div class="6u" id="box1">
      <section>
        <?php 
	$sticky = array(
	'posts_per_page' => 1,
	'post_status' => 'published',
	'post__in'  => get_option( 'sticky_posts' ),
	'ignore_sticky_posts' => 1
		
		);
	$sticky_post = new WP_Query($sticky);
			if( $sticky_post->have_posts() ): ?>
        <?php while( $sticky_post->have_posts() ):
					$sticky_post->the_post();?>
        <h2 class="entry-title"><a href="<?php the_permalink(); ?>" title="<?php printf( esc_attr__( 'Permalink to %s', 'project3' ), the_title_attribute( 'echo=0' ) ); ?>" rel="bookmark">
          <?php the_title(); ?>
          </a></h2>
        <div class="clearfix"> <a href="<?php the_permalink() ?>">
          <?php
                  if ( has_post_thumbnail() ) { 
                   the_post_thumbnail( array(180,120) ); ?>
          <?php } else { ?>
          <img src="<?php echo get_template_directory_uri(); ?>/images/javascript-ninja180x120.png" class="img-alignleft" alt="ninja"/>
          <?php } ?>
          </a>
          <?php the_excerpt(); 
                ?>
        </div>
        <?php       
endwhile; 
endif; ?>
      </section>
    </div>
    <?php get_sidebar('footer'); ?>
  </div>
</div>
</div>
<div id="copyright" class="5grid-layout">
  <section>
    <p>&copy; Telerik CMS Course | Design: <a href="http://academy.telerik.com/">Telerik Software Academy</a></p>
  </section>
</div>
<?php wp_footer(); ?>
</body></html>