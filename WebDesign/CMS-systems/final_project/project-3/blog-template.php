<?php
/**
 * Template Name: Blog Template
 */
get_header();
?>

<div class="9u">
  <div id="content">
    <h1>Blog</h1>
    <?php
	$paged = (get_query_var('paged')) ? get_query_var('paged') : 1;
	$blog_query = new WP_Query(array('category__not_in' => array(8), 'paged' => $paged, 'author' => 1));
			if( $blog_query->have_posts() ): ?>
    <?php while( $blog_query->have_posts() ):
					$blog_query->the_post();
		?>
    <section>
      <div class="post clearfix">
        <?php get_template_part( 'content-blog', 'blog' ); ?>
      </div>
    </section>
    <?php  endwhile; ?>
    <nav id="nav-below-centered">
      <?php  	  	  
	  // first variant of pagination
 $big = 999999999; 
 echo paginate_links( array(
    'base' => str_replace( $big, '%#%', esc_url( get_pagenum_link( $big ) ) ),
    'format' => '?paged=%#%',
    'current' => max( 1, get_query_var('paged') ),
    'total' => $blog_query->max_num_pages
) );
    ?>
    </nav>
    <?php // second variant of pagination ( Older posts -  Newer posts ) ?>
    <?php /*?>    <nav id="nav-below">
      <div class="nav-previous">
        <?php next_posts_link( '<span class="meta-nav">&laquo;</span> Older posts', $blog_query->max_num_pages, 'project3' ); ?>
      </div>
      <div class="nav-next">
        <?php previous_posts_link( 'Newer posts <span class="meta-nav">&raquo;</span>', $blog_query->max_num_pages, 'project3' ); ?>
      </div>
    </nav><?php */?>
    <?php endif; ?>
    <?php wp_reset_query(); ?>
  </div>
</div>
<?php get_sidebar('sidebar1');        
 get_footer(); ?>
