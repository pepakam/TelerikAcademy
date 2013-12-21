<?php
/**
 * @package WordPress
 * @subpackage project3
 */
?>

<header class="entry-header">
  <h2 class="entry-title"><a href="<?php the_permalink(); ?>" title="<?php printf( esc_attr__( 'Permalink to %s', 'project3' ), the_title_attribute( 'echo=0' ) ); ?>" rel="bookmark">
    <?php the_title(); ?>
    </a></h2>
</header>
<!-- end entry-header -->
<div class="entry-details"><!-- entry-details -->
  <p><?php echo get_the_date(); ?>
    <?php _e( 'by', 'project3' ); ?>
    <?php the_author() ?>
    <?php comments_popup_link( __( '0 comments', 'project3' ), __( '1 Comment', 'project3' ), __( '% Comments', 'project3' ) ); ?>
  </p>
  <?php if ( has_post_thumbnail() ): ?>
  <a href="<?php the_permalink(); ?>">
  <?php the_post_thumbnail('thumbnail'); ?>
  </a>
  <?php endif; ?>
</div>
<!-- end entry-details -->

<?php if ( is_archive() || is_search() ) : // Only display excerpts for archives and search. ?>
<?php the_excerpt(); ?>
<?php else : ?>
<?php the_content( __( 'Continue Reading &rarr;', 'project3' ) ); ?>
<?php wp_link_pages( array( 'before' => '<div class="page-link">' . __( 'Pages:', 'project3' ), 'after' => '</div>' ) ); ?>
<?php endif; ?>
<footer class="entry-meta">
  <p>
    <?php if ( count( get_the_category() ) ) : ?>
    <?php printf( __( 'Categories: %2$s', 'project3' ), 'entry-utility-prep entry-utility-prep-cat-links', get_the_category_list( ', ' ) ); ?> |
    <?php endif; ?>
    <?php $tags_list = get_the_tag_list( '', ', ' ); 
			if ( $tags_list ): ?>
    <?php printf( __( 'Tags: %2$s', 'project3' ), 'entry-utility-prep entry-utility-prep-tag-links', $tags_list ); ?> |
    <?php endif; ?>
    <a href="<?php echo get_permalink(); ?>">
    <?php _e( 'Permalink ', 'project3' ); ?>
    </a>
    <?php edit_post_link( __( 'Edit &rarr;', 'project3' ), '| <span class="edit-link">', '</span>' ); ?>
  </p>
</footer>
<!-- end entry-meta --> 

<!-- end entry-content --> 

