<?php
/**
 * The template for displaying 404 pages (Not Found).
 *
 */
get_header(); ?>

<div class="9u">
  <div id="content">
    <section>
      <div class="post clearfix lost">
        <p>
          <?php _e( 'It seems we can&rsquo;t find what you&rsquo;re looking for. Perhaps searching, or one of the links below, can help.', 'project3' ); ?>
        </p>
        <?php get_search_form(); ?>
        <?php the_widget( 'WP_Widget_Recent_Posts', array( 'number' => 10, ), array( 'widget_id' => '404' ) ); ?>
        <div class="widget">
          <h2 class="widgettitle">
            <?php _e( 'Most Used Categories', 'project3' ); ?>
          </h2>
          <ul>
            <?php wp_list_categories( array( 'hierarchical' => 0,'orderby' => 'count', 'order' => 'DESC', 'show_count' => 0, 'title_li' => '', 'number' => 10 ) ); ?>
          </ul>
        </div>
        <?php
					/* translators: %1$s: smilie */
					$archive_content = '<p>' . sprintf( __( 'Try looking in the monthly archives. %1$s', 'project3' ), convert_smilies( ':)' ) ) . '</p>';
					the_widget( 'WP_Widget_Archives', array('count' => 0 , 'dropdown' => 1 ), array( 'after_title' => '</h2>'.$archive_content ) );
					?>
        <?php the_widget( 'WP_Widget_Tag_Cloud' ); ?>
      </div>
    </section>
  </div>
</div>
<?php get_sidebar('sidebar1');        
 get_footer(); ?>
