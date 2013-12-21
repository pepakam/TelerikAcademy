<?php get_header(); ?>

<div class="9u">
  <div id="content">
    <?php if ( have_posts() ) : ?>
    <header class="page-header">
      <h1 class="page-title"><?php echo $wp_query->found_posts; ?> <?php printf( __( 'Search Results for: %s', 'project3' ), '<span>' . get_search_query() . '</span>' ); ?></h1>
    </header>
    <!--end page-header-->
    
    <?php /* Start the Loop */ ?>
    <?php while ( have_posts() ) : the_post(); ?>
    <section>
      <div class="post clearfix">
        <?php get_template_part( 'content', 'search' ); ?>
      </div>
    </section>
    <?php endwhile; ?>
    <?php /* Display navigation to next/previous pages when applicable */ ?>
    <?php if (  $wp_query->max_num_pages > 1 ) : ?>
    <nav id="nav-below">
      <div class="nav-previous">
        <?php next_posts_link( __( '<span class="meta-nav">&larr;</span> Older posts', 'project3' ) ); ?>
      </div>
      <div class="nav-next">
        <?php previous_posts_link( __( 'Newer posts <span class="meta-nav">&rarr;</span>', 'project3' ) ); ?>
      </div>
    </nav>
    <!-- end nav-below -->
    
    <?php endif; ?>
    <?php else : ?>
    <section>
      <div class="post clearfix">
        <article id="post-0" class="post no-results not-found">
          <header class="page-header">
            <h1 class="page-title">
              <?php _e( 'Nothing Found', 'project3' ); ?>
            </h1>
          </header>
          <div class="single-entry-content">
            <p>
              <?php _e( 'Sorry, but nothing matched your search criteria. Please try again with some different keywords.', 'project3' ); ?>
            </p>
            <?php get_search_form(); ?>
          </div>
        </article>
      </div>
    </section>
    <?php endif; ?>
  </div>
</div>
<!-- end content -->

<?php get_sidebar('sidebar2'); ?>
<?php get_footer(); ?>
