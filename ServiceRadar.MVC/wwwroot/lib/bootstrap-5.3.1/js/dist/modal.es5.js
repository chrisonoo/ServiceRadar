/*!
  * Bootstrap modal.js v5.3.1 (https://getbootstrap.com/)
  * Copyright 2011-2023 The Bootstrap Authors (https://github.com/twbs/bootstrap/graphs/contributors)
  * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
  */
'use strict';

var _createClass = (function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ('value' in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; })();

var _get = function get(_x, _x2, _x3) { var _again = true; _function: while (_again) { var object = _x, property = _x2, receiver = _x3; _again = false; if (object === null) object = Function.prototype; var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { _x = parent; _x2 = property; _x3 = receiver; _again = true; desc = parent = undefined; continue _function; } } else if ('value' in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } } };

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError('Cannot call a class as a function'); } }

function _inherits(subClass, superClass) { if (typeof superClass !== 'function' && superClass !== null) { throw new TypeError('Super expression must either be null or a function, not ' + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

(function (global, factory) {
  typeof exports === 'object' && typeof module !== 'undefined' ? module.exports = factory(require('./base-component.js'), require('./dom/event-handler.js'), require('./dom/selector-engine.js'), require('./util/backdrop.js'), require('./util/component-functions.js'), require('./util/focustrap.js'), require('./util/index.js'), require('./util/scrollbar.js')) : typeof define === 'function' && define.amd ? define(['./base-component', './dom/event-handler', './dom/selector-engine', './util/backdrop', './util/component-functions', './util/focustrap', './util/index', './util/scrollbar'], factory) : (global = typeof globalThis !== 'undefined' ? globalThis : global || self, global.Modal = factory(global.BaseComponent, global.EventHandler, global.SelectorEngine, global.Backdrop, global.ComponentFunctions, global.Focustrap, global.Index, global.Scrollbar));
})(undefined, function (BaseComponent, EventHandler, SelectorEngine, Backdrop, componentFunctions_js, FocusTrap, index_js, ScrollBarHelper) {
  'use strict';

  /**
   * --------------------------------------------------------------------------
   * Bootstrap modal.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */

  /**
   * Constants
   */

  var NAME = 'modal';
  var DATA_KEY = 'bs.modal';
  var EVENT_KEY = '.' + DATA_KEY;
  var DATA_API_KEY = '.data-api';
  var ESCAPE_KEY = 'Escape';
  var EVENT_HIDE = 'hide' + EVENT_KEY;
  var EVENT_HIDE_PREVENTED = 'hidePrevented' + EVENT_KEY;
  var EVENT_HIDDEN = 'hidden' + EVENT_KEY;
  var EVENT_SHOW = 'show' + EVENT_KEY;
  var EVENT_SHOWN = 'shown' + EVENT_KEY;
  var EVENT_RESIZE = 'resize' + EVENT_KEY;
  var EVENT_CLICK_DISMISS = 'click.dismiss' + EVENT_KEY;
  var EVENT_MOUSEDOWN_DISMISS = 'mousedown.dismiss' + EVENT_KEY;
  var EVENT_KEYDOWN_DISMISS = 'keydown.dismiss' + EVENT_KEY;
  var EVENT_CLICK_DATA_API = 'click' + EVENT_KEY + DATA_API_KEY;
  var CLASS_NAME_OPEN = 'modal-open';
  var CLASS_NAME_FADE = 'fade';
  var CLASS_NAME_SHOW = 'show';
  var CLASS_NAME_STATIC = 'modal-static';
  var OPEN_SELECTOR = '.modal.show';
  var SELECTOR_DIALOG = '.modal-dialog';
  var SELECTOR_MODAL_BODY = '.modal-body';
  var SELECTOR_DATA_TOGGLE = '[data-bs-toggle="modal"]';
  var Default = {
    backdrop: true,
    focus: true,
    keyboard: true
  };
  var DefaultType = {
    backdrop: '(boolean|string)',
    focus: 'boolean',
    keyboard: 'boolean'
  };

  /**
   * Class definition
   */

  var Modal = (function (_BaseComponent) {
    _inherits(Modal, _BaseComponent);

    function Modal(element, config) {
      _classCallCheck(this, Modal);

      _get(Object.getPrototypeOf(Modal.prototype), 'constructor', this).call(this, element, config);
      this._dialog = SelectorEngine.findOne(SELECTOR_DIALOG, this._element);
      this._backdrop = this._initializeBackDrop();
      this._focustrap = this._initializeFocusTrap();
      this._isShown = false;
      this._isTransitioning = false;
      this._scrollBar = new ScrollBarHelper();
      this._addEventListeners();
    }

    /**
     * Data API implementation
     */

    // Getters

    _createClass(Modal, [{
      key: 'toggle',

      // Public
      value: function toggle(relatedTarget) {
        return this._isShown ? this.hide() : this.show(relatedTarget);
      }
    }, {
      key: 'show',
      value: function show(relatedTarget) {
        var _this = this;

        if (this._isShown || this._isTransitioning) {
          return;
        }
        var showEvent = EventHandler.trigger(this._element, EVENT_SHOW, {
          relatedTarget: relatedTarget
        });
        if (showEvent.defaultPrevented) {
          return;
        }
        this._isShown = true;
        this._isTransitioning = true;
        this._scrollBar.hide();
        document.body.classList.add(CLASS_NAME_OPEN);
        this._adjustDialog();
        this._backdrop.show(function () {
          return _this._showElement(relatedTarget);
        });
      }
    }, {
      key: 'hide',
      value: function hide() {
        var _this2 = this;

        if (!this._isShown || this._isTransitioning) {
          return;
        }
        var hideEvent = EventHandler.trigger(this._element, EVENT_HIDE);
        if (hideEvent.defaultPrevented) {
          return;
        }
        this._isShown = false;
        this._isTransitioning = true;
        this._focustrap.deactivate();
        this._element.classList.remove(CLASS_NAME_SHOW);
        this._queueCallback(function () {
          return _this2._hideModal();
        }, this._element, this._isAnimated());
      }
    }, {
      key: 'dispose',
      value: function dispose() {
        EventHandler.off(window, EVENT_KEY);
        EventHandler.off(this._dialog, EVENT_KEY);
        this._backdrop.dispose();
        this._focustrap.deactivate();
        _get(Object.getPrototypeOf(Modal.prototype), 'dispose', this).call(this);
      }
    }, {
      key: 'handleUpdate',
      value: function handleUpdate() {
        this._adjustDialog();
      }

      // Private
    }, {
      key: '_initializeBackDrop',
      value: function _initializeBackDrop() {
        return new Backdrop({
          isVisible: Boolean(this._config.backdrop),
          // 'static' option will be translated to true, and booleans will keep their value,
          isAnimated: this._isAnimated()
        });
      }
    }, {
      key: '_initializeFocusTrap',
      value: function _initializeFocusTrap() {
        return new FocusTrap({
          trapElement: this._element
        });
      }
    }, {
      key: '_showElement',
      value: function _showElement(relatedTarget) {
        var _this3 = this;

        // try to append dynamic modal
        if (!document.body.contains(this._element)) {
          document.body.append(this._element);
        }
        this._element.style.display = 'block';
        this._element.removeAttribute('aria-hidden');
        this._element.setAttribute('aria-modal', true);
        this._element.setAttribute('role', 'dialog');
        this._element.scrollTop = 0;
        var modalBody = SelectorEngine.findOne(SELECTOR_MODAL_BODY, this._dialog);
        if (modalBody) {
          modalBody.scrollTop = 0;
        }
        index_js.reflow(this._element);
        this._element.classList.add(CLASS_NAME_SHOW);
        var transitionComplete = function transitionComplete() {
          if (_this3._config.focus) {
            _this3._focustrap.activate();
          }
          _this3._isTransitioning = false;
          EventHandler.trigger(_this3._element, EVENT_SHOWN, {
            relatedTarget: relatedTarget
          });
        };
        this._queueCallback(transitionComplete, this._dialog, this._isAnimated());
      }
    }, {
      key: '_addEventListeners',
      value: function _addEventListeners() {
        var _this4 = this;

        EventHandler.on(this._element, EVENT_KEYDOWN_DISMISS, function (event) {
          if (event.key !== ESCAPE_KEY) {
            return;
          }
          if (_this4._config.keyboard) {
            _this4.hide();
            return;
          }
          _this4._triggerBackdropTransition();
        });
        EventHandler.on(window, EVENT_RESIZE, function () {
          if (_this4._isShown && !_this4._isTransitioning) {
            _this4._adjustDialog();
          }
        });
        EventHandler.on(this._element, EVENT_MOUSEDOWN_DISMISS, function (event) {
          // a bad trick to segregate clicks that may start inside dialog but end outside, and avoid listen to scrollbar clicks
          EventHandler.one(_this4._element, EVENT_CLICK_DISMISS, function (event2) {
            if (_this4._element !== event.target || _this4._element !== event2.target) {
              return;
            }
            if (_this4._config.backdrop === 'static') {
              _this4._triggerBackdropTransition();
              return;
            }
            if (_this4._config.backdrop) {
              _this4.hide();
            }
          });
        });
      }
    }, {
      key: '_hideModal',
      value: function _hideModal() {
        var _this5 = this;

        this._element.style.display = 'none';
        this._element.setAttribute('aria-hidden', true);
        this._element.removeAttribute('aria-modal');
        this._element.removeAttribute('role');
        this._isTransitioning = false;
        this._backdrop.hide(function () {
          document.body.classList.remove(CLASS_NAME_OPEN);
          _this5._resetAdjustments();
          _this5._scrollBar.reset();
          EventHandler.trigger(_this5._element, EVENT_HIDDEN);
        });
      }
    }, {
      key: '_isAnimated',
      value: function _isAnimated() {
        return this._element.classList.contains(CLASS_NAME_FADE);
      }
    }, {
      key: '_triggerBackdropTransition',
      value: function _triggerBackdropTransition() {
        var _this6 = this;

        var hideEvent = EventHandler.trigger(this._element, EVENT_HIDE_PREVENTED);
        if (hideEvent.defaultPrevented) {
          return;
        }
        var isModalOverflowing = this._element.scrollHeight > document.documentElement.clientHeight;
        var initialOverflowY = this._element.style.overflowY;
        // return if the following background transition hasn't yet completed
        if (initialOverflowY === 'hidden' || this._element.classList.contains(CLASS_NAME_STATIC)) {
          return;
        }
        if (!isModalOverflowing) {
          this._element.style.overflowY = 'hidden';
        }
        this._element.classList.add(CLASS_NAME_STATIC);
        this._queueCallback(function () {
          _this6._element.classList.remove(CLASS_NAME_STATIC);
          _this6._queueCallback(function () {
            _this6._element.style.overflowY = initialOverflowY;
          }, _this6._dialog);
        }, this._dialog);
        this._element.focus();
      }

      /**
       * The following methods are used to handle overflowing modals
       */

    }, {
      key: '_adjustDialog',
      value: function _adjustDialog() {
        var isModalOverflowing = this._element.scrollHeight > document.documentElement.clientHeight;
        var scrollbarWidth = this._scrollBar.getWidth();
        var isBodyOverflowing = scrollbarWidth > 0;
        if (isBodyOverflowing && !isModalOverflowing) {
          var property = index_js.isRTL() ? 'paddingLeft' : 'paddingRight';
          this._element.style[property] = scrollbarWidth + 'px';
        }
        if (!isBodyOverflowing && isModalOverflowing) {
          var property = index_js.isRTL() ? 'paddingRight' : 'paddingLeft';
          this._element.style[property] = scrollbarWidth + 'px';
        }
      }
    }, {
      key: '_resetAdjustments',
      value: function _resetAdjustments() {
        this._element.style.paddingLeft = '';
        this._element.style.paddingRight = '';
      }

      // Static
    }], [{
      key: 'jQueryInterface',
      value: function jQueryInterface(config, relatedTarget) {
        return this.each(function () {
          var data = Modal.getOrCreateInstance(this, config);
          if (typeof config !== 'string') {
            return;
          }
          if (typeof data[config] === 'undefined') {
            throw new TypeError('No method named "' + config + '"');
          }
          data[config](relatedTarget);
        });
      }
    }, {
      key: 'Default',
      get: function get() {
        return Default;
      }
    }, {
      key: 'DefaultType',
      get: function get() {
        return DefaultType;
      }
    }, {
      key: 'NAME',
      get: function get() {
        return NAME;
      }
    }]);

    return Modal;
  })(BaseComponent);

  EventHandler.on(document, EVENT_CLICK_DATA_API, SELECTOR_DATA_TOGGLE, function (event) {
    var _this7 = this;

    var target = SelectorEngine.getElementFromSelector(this);
    if (['A', 'AREA'].includes(this.tagName)) {
      event.preventDefault();
    }
    EventHandler.one(target, EVENT_SHOW, function (showEvent) {
      if (showEvent.defaultPrevented) {
        // only register focus restorer if modal will actually get shown
        return;
      }
      EventHandler.one(target, EVENT_HIDDEN, function () {
        if (index_js.isVisible(_this7)) {
          _this7.focus();
        }
      });
    });

    // avoid conflict when clicking modal toggler while another one is open
    var alreadyOpen = SelectorEngine.findOne(OPEN_SELECTOR);
    if (alreadyOpen) {
      Modal.getInstance(alreadyOpen).hide();
    }
    var data = Modal.getOrCreateInstance(target);
    data.toggle(this);
  });
  componentFunctions_js.enableDismissTrigger(Modal);

  /**
   * jQuery
   */

  index_js.defineJQueryPlugin(Modal);

  return Modal;
});
//# sourceMappingURL=modal.js.map

