<?php
/**
 * @package WordPress
 * @subpackage project3
 */
?>

<article id="post-<?php the_ID(); ?>" <?php post_class(); ?>>
  <header class="page-entry-header">
    <h1 class="entry-title">
      <?php the_title(); ?>
    </h1>
  </header>
  <!--end page-entry-hader-->
  
  <div class="single-entry-content clearfix">
    <?php the_content(); ?>
    <?php wp_link_pages( array( 'before' => '<div class="page-link">' . __( 'Pages:', 'project3' ), 'after' => '</div>' ) ); ?>
    <?php edit_post_link( __( 'Edit &rarr;', 'project3' ), '<span class="edit-link">', '</span>' ); ?>
  </div>
  <!--end entry-content--> 
  
</article>
<!-- end post-<?php the_ID(); ?> --> 
