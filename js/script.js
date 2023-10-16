class Modal {
  constructor(options) {
    let defaultOptions = {
      isOpen: () => {},
    
    }
    this.options = Object.assign(defaultOptions, options);
    this.modal = document.querySelector('.modal');
    this.speed = false;
    this.animation = false;
    this.isOpen = false;
    this.modalContainer = false;
    this.previousActiveElement = false;
    this.fixBlocks = document.querySelectorAll('.fix-block');
    this.events();
  }

  events() {
    if (this.modal) {
      document.addEventListener('click', function(e) {
        const clickedElement = e.target.closest('[data-path]');
        if (clickedElement) {
          let target = clickedElement.dataset.path;
          let animation = clickedElement.dataset.animation;
          let speed = clickedElement.dataset.speed;
          this.animation = animation ? animation : 'fade';
          this.speed = speed ? parseInt(speed) : 300;
          this.modalContainer = document.querySelector(`[data-target="${target}"]`);
          this.open();
          return;
        }

        if (e.target.closest('.modal-close')) {
          this.close();
          return;
        }
      }.bind(this));
    }
  }

  open() {
    // открыть окно
    // сайт не скроллится
    // нет прыжка
    // фокус внутри окна
    // выделение первого
    // анимация
    this.modal.style.setProperty('--transition-time', `${this.speed / 1000}s`);
    this.modal.classList.add('is-open');
    this.disableScroll();
    
    this.modalContainer.classList.add('modal-open');
    this.modalContainer.classList.add(this.animation);

    setTimeout(() => {
      this.modalContainer.classList.add('animate-open');
      this.options.isOpen(this);
      this.isOpen = true;
      this.focusTrap();
    }, this.speed);
  }

  close() {

  }

  focusCatch(e) {

  }

  focusTrap() {

  }

  disableScroll() {

  }

  enableScroll() {

  }

  lockPadding () {

  }

  unlockPadding () {
    
  }

}

const modal = new Modal({
  isOpen: () => {
    console.log('opened');
  },
  
});