<?php /*?>Variant-I  if there is no dinamic sidebar, there is no banner area<?php */?>
<?php /*?><?php if ( is_active_sidebar( 'horizontal-1' ) ) : ?>

<div class="5grid-layout">
  <div class="row">
    <div class="12u">
      <?php dynamic_sidebar( 'horizontal-1' ); ?>
    </div>
  </div>
</div>
<?php endif; ?><?php */?>
<?php /*?>end of Variant-I*/?>


<?php /*?>Variant-II  if there is no dinamic sidebar, there is image placeholder<?php */?>
<?php if( ! dynamic_sidebar('horizontal-1') ):?>

<div class="5grid-layout">
  <div class="row">
    <div class="12u">
      <div id="banner"><a href="#"><img src="<?php echo get_template_directory_uri(); ?>/images/banner.png" alt=""></a></div>
    </div>
  </div>
</div>
<?php endif; ?>
<?php /*?>end of Variant-II*/?>
