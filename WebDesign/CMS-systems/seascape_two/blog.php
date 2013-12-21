<?php
/**
 * Template Name: Blog Template
 */
get_header();
?>

		<h1>Blog</h1>
		<?php
			$blog_query = new WP_Query('author=1');
			if( $blog_query->have_posts() ):
				while( $blog_query->have_posts() ):
					$blog_query->the_post();
		
		?>           
         <h2><a href="<?php the_permalink(); ?>" title="<?php the_title_attribute(); ?>"><?php the_title(); ?></a></h2>
            
				<?php the_content(); ?>            
            
        <?php 
        		endwhile;
        	endif;
        	wp_reset_query();
        ?>
<?php get_footer(); ?>