﻿function showNext() { ++i; if (i > n) { i = 1 } window.f.next("bars3d"); $(".Txt").fadeOut(500); $(".Txt:nth-child(" + i + ")").fadeIn(1e3) } var i = 1; var interval = 1e4; var timerId; $(function () { if (!flux.browser.supportsTransitions) /*alert("Flux Slider requires a browser that supports CSS3 transitions");*/ window.f = new flux.slider("#silder", { pagination: false, width: 1100, height: 393, delay: interval, autoplay: false }); $("#flexiselDemo1").flexisel(); $(".ColupsData").hide(); $(".Colups").click(function () { if ($(this).hasClass("Colups2")) { $(".ColupsData").hide(); $(this).children(".ColupsData").hide(300); $(".Colups").removeClass("Colups2") } else { $(".ColupsData").hide(); $(this).children(".ColupsData").show(300); $(".Colups").removeClass("Colups2"); $(this).addClass("Colups2") } }); $(".Txt").hide(); $(".Txt:nth-child(1)").fadeIn(1e3); timerId = setInterval(function () { showNext() }, interval); $("header").mouseenter(function () { clearInterval(timerId) }); $("header").mouseleave(function () { timerId = setInterval(function () { showNext() }, interval) }); var t, n = $(".Menu"), r = n.outerHeight() + 15, i = n.children(), s = i.map(function () { var e = $($(this).attr("href")); if (e.length) { return e } }); i.click(function (e) { var t = $(this).attr("href"), n = t === "#" ? 0 : $(t).offset().top - r + 1; $("html, body").stop().animate({ scrollTop: n }, 300); e.preventDefault() }); $(".TopIcon a").click(function () { var t = $(this).attr("href"), n = t === "#" ? 0 : $(t).offset().top - r + 1; $("html, body").stop().animate({ scrollTop: n }, 300); e.preventDefault() }) }); (function (e, t, n, r, i, s, o) { e["GoogleAnalyticsObject"] = i; e[i] = e[i] || function () { (e[i].q = e[i].q || []).push(arguments) }, e[i].l = 1 * new Date; s = t.createElement(n), o = t.getElementsByTagName(n)[0]; s.async = 1; s.src = r; o.parentNode.insertBefore(s, o) })(window, document, "script", "//www.google-analytics.com/analytics.js", "ga"); ga("create", "UA-46073047-2", "aktco.com"); ga("send", "pageview"); window.flux = { version: "1.4.4" }; (function (e) { flux.slider = function (t, n) { flux.browser.init(); flux.browser.supportsTransitions || window.console && window.console.error && console.error("Flux Slider requires a browser that supports CSS3 transitions"); var r = this; this.element = e(t); this.transitions = []; for (var i in flux.transitions) this.transitions.push(i); this.options = e.extend({ autoplay: true, transitions: this.transitions, delay: 4e3, pagination: true, controls: false, captions: false, width: null, height: null, onTransitionEnd: null }, n); this.height = this.options.height ? this.options.height : null; this.width = this.options.width ? this.options.width : null; var s = []; e(this.options.transitions).each(function (e, t) { var n = new flux.transitions[t](this), r = true; if (n.options.requires3d && !flux.browser.supports3d) r = false; if (n.options.compatibilityCheck) r = n.options.compatibilityCheck(); r && s.push(t) }); this.options.transitions = s; this.images = []; this.currentImageIndex = this.imageLoadedCount = 0; this.nextImageIndex = 1; this.playing = false; this.container = e('<div class="fluxslider"></div>').appendTo(this.element); this.surface = e('<div class="surface" style="position: relative"></div>').appendTo(this.container); this.container.bind("click", function (t) { if (e(t.target).hasClass("hasLink")) window.location = e(t.target).data("href") }); this.imageContainer = e('<div class="images loading"></div>').css({ position: "relative", overflow: "hidden", "min-height": "100px" }).appendTo(this.surface); this.width && this.height && this.imageContainer.css({ width: this.width + "px", height: this.height + "px" }); this.image1 = e('<div class="image1" style="height: 100%; width: 100%"></div>').appendTo(this.imageContainer); this.image2 = e('<div class="image2" style="height: 100%; width: 100%"></div>').appendTo(this.imageContainer); e(this.image1).add(this.image2).css({ position: "absolute", top: "0px", left: "0px" }); this.element.find("img, a img").each(function (t, n) { var i = n.cloneNode(false), s = e(n).parent(); s.is("a") && e(i).data("href", s.attr("href")); r.images.push(i); e(n).remove() }); for (i = 0; i < this.images.length; i++) { var o = new Image; o.onload = function () { r.imageLoadedCount++; r.width = r.width ? r.width : this.width; r.height = r.height ? r.height : this.height; if (r.imageLoadedCount >= r.images.length) { r.finishedLoading(); r.setupImages() } }; o.src = this.images[i].src } this.element.bind("fluxTransitionEnd", function (e, t) { if (r.options.onTransitionEnd) { e.preventDefault(); r.options.onTransitionEnd(t) } }); this.options.autoplay && this.start(); this.element.bind("swipeLeft", function () { r.next(null, { direction: "left" }) }).bind("swipeRight", function () { r.prev(null, { direction: "right" }) }); setTimeout(function () { e(window).focus(function () { r.isPlaying() && r.next() }) }, 100) }; flux.slider.prototype = { constructor: flux.slider, playing: false, start: function () { var e = this; this.playing = true; this.interval = setInterval(function () { console.log("play"); e.transition() }, this.options.delay) }, stop: function () { this.playing = false; clearInterval(this.interval); this.interval = null }, isPlaying: function () { return this.playing }, next: function (e, t) { t = t || {}; t.direction = "left"; this.showImage(this.currentImageIndex + 1, e, t) }, prev: function (e, t) { t = t || {}; t.direction = "right"; this.showImage(this.currentImageIndex - 1, e, t) }, showImage: function (e, t, n) { this.setNextIndex(e); this.setupImages(); this.transition(t, n) }, finishedLoading: function () { var t = this; this.container.css({ width: this.width + "px", height: this.height + "px" }); this.imageContainer.removeClass("loading"); if (this.options.pagination) { this.pagination = e('<ul class="pagination"></ul>').css({ margin: "0px", padding: "0px", "text-align": "center" }); this.pagination.bind("click", function (n) { n.preventDefault(); t.showImage(e(n.target).data("index")) }); e(this.images).each(function (n) { var r = e('<li data-index="' + n + '">' + (n + 1) + "</li>").css({ display: "inline-block", "margin-left": "0.5em", cursor: "pointer" }).appendTo(t.pagination); n == 0 && r.css("margin-left", 0).addClass("current") }); this.container.append(this.pagination) } e(this.imageContainer).css({ width: this.width + "px", height: this.height + "px" }); e(this.image1).css({ width: this.width + "px", height: this.height + "px" }); e(this.image2).css({ width: this.width + "px", height: this.height + "px" }); this.container.css({ width: this.width + "px", height: this.height + (this.options.pagination ? this.pagination.height() : 0) + "px" }); if (this.options.controls) { var n = { padding: "4px 10px 10px", "font-size": "60px", "font-family": "arial, sans-serif", "line-height": "1em", "font-weight": "bold", color: "#FFF", "text-decoration": "none", background: "rgba(0,0,0,0.5)", position: "absolute", "z-index": 2e3 }; this.nextButton = e('<a href="#">»</a>').css(n).css3({ "border-radius": "4px" }).appendTo(this.surface).bind("click", function (e) { e.preventDefault(); t.next() }); this.prevButton = e('<a href="#">«</a>').css(n).css3({ "border-radius": "4px" }).appendTo(this.surface).bind("click", function (e) { e.preventDefault(); t.prev() }); n = (this.height - this.nextButton.height()) / 2; this.nextButton.css({ top: n + "px", right: "10px" }); this.prevButton.css({ top: n + "px", left: "10px" }) } if (this.options.captions) this.captionBar = e('<div class="caption"></div>').css({ background: "rgba(0,0,0,0.6)", color: "#FFF", "font-size": "16px", "font-family": "helvetica, arial, sans-serif", "text-decoration": "none", "font-weight": "bold", padding: "1.5em 1em", opacity: 0, position: "absolute", "z-index": 110, width: "100%", bottom: 0 }).css3({ "transition-property": "opacity", "transition-duration": "800ms", "box-sizing": "border-box" }).prependTo(this.surface); this.updateCaption() }, setupImages: function () { var t = this.getImage(this.currentImageIndex), n = { "background-image": 'url("' + t.src + '")', "z-index": 101, cursor: "auto" }; if (e(t).data("href")) { n.cursor = "pointer"; this.image1.addClass("hasLink"); this.image1.data("href", e(t).data("href")) } else { this.image1.removeClass("hasLink"); this.image1.data("href", null) } this.image1.css(n).children().remove(); this.image2.css({ "background-image": 'url("' + this.getImage(this.nextImageIndex).src + '")', "z-index": 100 }).show(); if (this.options.pagination && this.pagination) { this.pagination.find("li.current").removeClass("current"); e(this.pagination.find("li")[this.currentImageIndex]).addClass("current") } }, transition: function (t, n) { if (t == undefined || !flux.transitions[t]) t = this.options.transitions[Math.floor(Math.random() * this.options.transitions.length)]; var r = null; try { r = new flux.transitions[t](this, e.extend(this.options[t] ? this.options[t] : {}, n)) } catch (i) { r = new flux.transition(this, { fallback: true }) } r.run(); this.currentImageIndex = this.nextImageIndex; this.setNextIndex(this.currentImageIndex + 1); this.updateCaption() }, updateCaption: function () { var t = e(this.getImage(this.currentImageIndex)).attr("title"); if (this.options.captions && this.captionBar) { t !== "" && this.captionBar.html(t); this.captionBar.css("opacity", t === "" ? 0 : 1) } }, getImage: function (e) { e %= this.images.length; return this.images[e] }, setNextIndex: function (e) { if (e == undefined) e = this.currentImageIndex + 1; this.nextImageIndex = e; if (this.nextImageIndex > this.images.length - 1) this.nextImageIndex = 0; if (this.nextImageIndex < 0) this.nextImageIndex = this.images.length - 1 }, increment: function () { this.currentImageIndex++; if (this.currentImageIndex > this.images.length - 1) this.currentImageIndex = 0 } } })(window.jQuery || window.Zepto); (function (e) { flux.browser = { init: function () { if (flux.browser.supportsTransitions === undefined) { document.createElement("div"); var t = ["-webkit", "-moz", "-o", "-ms"]; flux.browser.supportsTransitions = window.Modernizr && Modernizr.csstransitions !== undefined ? Modernizr.csstransitions : this.supportsCSSProperty("Transition"); if (window.Modernizr && Modernizr.csstransforms3d !== undefined) flux.browser.supports3d = Modernizr.csstransforms3d; else { flux.browser.supports3d = this.supportsCSSProperty("Perspective"); if (flux.browser.supports3d && "webkitPerspective" in e("body").get(0).style) { var n = e('<div id="csstransform3d"></div>'); t = e('<style media="(transform-3d), (' + t.join("-transform-3d),(") + '-transform-3d)">div#csstransform3d { position: absolute; left: 9px }</style>'); e("body").append(n); e("head").append(t); flux.browser.supports3d = n.get(0).offsetLeft == 9; n.remove(); t.remove() } } } }, supportsCSSProperty: function (e) { for (var t = document.createElement("div"), n = ["Webkit", "Moz", "O", "Ms"], r = false, i = 0; i < n.length; i++) if (n[i] + e in t.style) r = r || true; return r }, translate: function (e, t, n) { e = e != undefined ? e : 0; t = t != undefined ? t : 0; n = n != undefined ? n : 0; return "translate" + (flux.browser.supports3d ? "3d(" : "(") + e + "px," + t + (flux.browser.supports3d ? "px," + n + "px)" : "px)") }, rotateX: function (e) { return flux.browser.rotate("x", e) }, rotateY: function (e) { return flux.browser.rotate("y", e) }, rotateZ: function (e) { return flux.browser.rotate("z", e) }, rotate: function (e, t) { if (!e in { x: "", y: "", z: "" }) e = "z"; t = t != undefined ? t : 0; return flux.browser.supports3d ? "rotate3d(" + (e == "x" ? "1" : "0") + ", " + (e == "y" ? "1" : "0") + ", " + (e == "z" ? "1" : "0") + ", " + t + "deg)" : e == "z" ? "rotate(" + t + "deg)" : "" } }; e(function () { flux.browser.init() }) })(window.jQuery || window.Zepto); (function (e) { e.fn.css3 = function (e) { var t = {}, n = ["webkit", "moz", "ms", "o"], r; for (r in e) { for (var i = 0; i < n.length; i++) t["-" + n[i] + "-" + r] = e[r]; t[r] = e[r] } this.css(t); return this }; e.fn.transitionEnd = function (t) { for (var n = ["webkitTransitionEnd", "transitionend", "oTransitionEnd"], r = 0; r < n.length; r++) this.bind(n[r], function (r) { for (var i = 0; i < n.length; i++) e(this).unbind(n[i]); t && t.call(this, r) }); return this }; flux.transition = function (t, n) { this.options = e.extend({ requires3d: false, after: function () { } }, n); this.slider = t; if (this.options.requires3d && !flux.browser.supports3d || !flux.browser.supportsTransitions || this.options.fallback === true) { var r = this; this.options.after = undefined; this.options.setup = function () { r.fallbackSetup() }; this.options.execute = function () { r.fallbackExecute() } } }; flux.transition.prototype = { constructor: flux.transition, hasFinished: false, run: function () { var e = this; this.options.setup !== undefined && this.options.setup.call(this); this.slider.image1.css({ "background-image": "none" }); this.slider.imageContainer.css("overflow", this.options.requires3d ? "visible" : "hidden"); setTimeout(function () { e.options.execute !== undefined && e.options.execute.call(e) }, 5) }, finished: function () { if (!this.hasFinished) { this.hasFinished = true; this.options.after && this.options.after.call(this); this.slider.imageContainer.css("overflow", "hidden"); this.slider.setupImages(); this.slider.element.trigger("fluxTransitionEnd", { currentImage: this.slider.getImage(this.slider.currentImageIndex) }) } }, fallbackSetup: function () { }, fallbackExecute: function () { this.finished() } }; flux.transitions = {}; flux.transition_grid = function (t, n) { return new flux.transition(t, e.extend({ columns: 6, rows: 6, forceSquare: false, setup: function () { var t = this.slider.image1.width(), n = this.slider.image1.height(), r = Math.floor(t / this.options.columns), i = Math.floor(n / this.options.rows); if (this.options.forceSquare) { i = r; this.options.rows = Math.floor(n / i) } t = t - this.options.columns * r; var s = Math.ceil(t / this.options.columns); n = n - this.options.rows * i; var o = Math.ceil(n / this.options.rows); this.slider.image1.height(); for (var u = 0, a = 0, f = document.createDocumentFragment(), l = 0; l < this.options.columns; l++) { var c = r; a = 0; if (t > 0) { var h = t >= s ? s : t; c += h; t -= h } for (var p = 0; p < this.options.rows; p++) { var d = i; h = n; if (h > 0) { h = h >= o ? o : h; d += h } h = e('<div class="tile tile-' + l + "-" + p + '"></div>').css({ width: c + "px", height: d + "px", position: "absolute", top: a + "px", left: u + "px" }); this.options.renderTile.call(this, h, l, p, c, d, u, a); f.appendChild(h.get(0)); a += d } u += c } this.slider.image1.get(0).appendChild(f) }, execute: function () { var e = this, t = this.slider.image1.height(), n = this.slider.image1.find("div.barcontainer"); this.slider.image2.hide(); n.last().transitionEnd(function () { e.slider.image2.show(); e.finished() }); n.css3({ transform: flux.browser.rotateX(-90) + " " + flux.browser.translate(0, t / 2, t / 2) }) }, renderTile: function () { } }, n)) } })(window.jQuery || window.Zepto); (function (e) { flux.transitions.bars = function (t, n) { return new flux.transition_grid(t, e.extend({ columns: 10, rows: 1, delayBetweenBars: 40, renderTile: function (t, n, r, i, s, o) { e(t).css({ "background-image": this.slider.image1.css("background-image"), "background-position": "-" + o + "px 0px" }).css3({ "transition-duration": "400ms", "transition-timing-function": "ease-in", "transition-property": "all", "transition-delay": n * this.options.delayBetweenBars + "ms" }) }, execute: function () { var t = this, n = this.slider.image1.height(), r = this.slider.image1.find("div.tile"); e(r[r.length - 1]).transitionEnd(function () { t.finished() }); setTimeout(function () { r.css({ opacity: "0.5" }).css3({ transform: flux.browser.translate(0, n) }) }, 50) } }, n)) } })(window.jQuery || window.Zepto); (function (e) { flux.transitions.bars3d = function (t, n) { return new flux.transition_grid(t, e.extend({ requires3d: true, columns: 7, rows: 1, delayBetweenBars: 150, perspective: 1e3, renderTile: function (t, n, r, i, s, o) { r = e('<div class="bar-' + n + '"></div>').css({ width: i + "px", height: "100%", position: "absolute", top: "0px", left: "0px", "z-index": 200, "background-image": this.slider.image1.css("background-image"), "background-position": "-" + o + "px 0px", "background-repeat": "no-repeat" }).css3({ "backface-visibility": "hidden" }); var u = e(r.get(0).cloneNode(false)).css({ "background-image": this.slider.image2.css("background-image") }).css3({ transform: flux.browser.rotateX(90) + " " + flux.browser.translate(0, -s / 2, s / 2) }), a = e('<div class="side bar-' + n + '"></div>').css({ width: s + "px", height: s + "px", position: "absolute", top: "0px", left: "0px", background: "#222", "z-index": 190 }).css3({ transform: flux.browser.rotateY(90) + " " + flux.browser.translate(s / 2, 0, -s / 2) + " " + flux.browser.rotateY(180), "backface-visibility": "hidden" }); s = e(a.get(0).cloneNode(false)).css3({ transform: flux.browser.rotateY(90) + " " + flux.browser.translate(s / 2, 0, i - s / 2) }); e(t).css({ width: i + "px", height: "100%", position: "absolute", top: "0px", left: o + "px", "z-index": n > this.options.columns / 2 ? 1e3 - n : 1e3 }).css3({ "transition-duration": "800ms", "transition-timing-function": "linear", "transition-property": "all", "transition-delay": n * this.options.delayBetweenBars + "ms", "transform-style": "preserve-3d" }).append(r).append(u).append(a).append(s) }, execute: function () { this.slider.image1.css3({ perspective: this.options.perspective, "perspective-origin": "50% 50%" }).css({ "-moz-transform": "perspective(" + this.options.perspective + "px)", "-moz-perspective": "none", "-moz-transform-style": "preserve-3d" }); var e = this, t = this.slider.image1.height(), n = this.slider.image1.find("div.tile"); this.slider.image2.hide(); n.last().transitionEnd(function () { e.slider.image1.css3({ "transform-style": "flat" }); e.slider.image2.show(); e.finished() }); setTimeout(function () { n.css3({ transform: flux.browser.rotateX(-90) + " " + flux.browser.translate(0, t / 2, t / 2) }) }, 50) } }, n)) } })(window.jQuery || window.Zepto); (function (e) { flux.transitions.blinds = function (t, n) { return new flux.transitions.bars(t, e.extend({ execute: function () { var t = this; this.slider.image1.height(); var n = this.slider.image1.find("div.tile"); e(n[n.length - 1]).transitionEnd(function () { t.finished() }); setTimeout(function () { n.css({ opacity: "0.5" }).css3({ transform: "scalex(0.0001)" }) }, 50) } }, n)) } })(window.jQuery || window.Zepto); (function (e) { flux.transitions.blinds3d = function (t, n) { return new flux.transitions.tiles3d(t, e.extend({ forceSquare: false, rows: 1, columns: 6 }, n)) } })(window.jQuery || window.Zepto); (function (e) { flux.transitions.zip = function (t, n) { return new flux.transitions.bars(t, e.extend({ execute: function () { var t = this, n = this.slider.image1.height(), r = this.slider.image1.find("div.tile"); e(r[r.length - 1]).transitionEnd(function () { t.finished() }); setTimeout(function () { r.each(function (t, r) { e(r).css({ opacity: "0.3" }).css3({ transform: flux.browser.translate(0, t % 2 ? "-" + 2 * n : n) }) }) }, 20) } }, n)) } })(window.jQuery || window.Zepto); (function (e) { flux.transitions.blocks = function (t, n) { return new flux.transition_grid(t, e.extend({ forceSquare: true, delayBetweenBars: 100, renderTile: function (t, n, r, i, s, o, u) { n = Math.floor(Math.random() * 10 * this.options.delayBetweenBars); e(t).css({ "background-image": this.slider.image1.css("background-image"), "background-position": "-" + o + "px -" + u + "px" }).css3({ "transition-duration": "350ms", "transition-timing-function": "ease-in", "transition-property": "all", "transition-delay": n + "ms" }); if (this.maxDelay === undefined) this.maxDelay = 0; if (n > this.maxDelay) { this.maxDelay = n; this.maxDelayTile = t } }, execute: function () { var t = this, n = this.slider.image1.find("div.tile"); this.maxDelayTile.transitionEnd(function () { t.finished() }); setTimeout(function () { n.each(function (t, n) { e(n).css({ opacity: "0" }).css3({ transform: "scale(0.8)" }) }) }, 50) } }, n)) } })(window.jQuery || window.Zepto); (function (e) { flux.transitions.blocks2 = function (t, n) { return new flux.transition_grid(t, e.extend({ cols: 12, forceSquare: true, delayBetweenDiagnols: 150, renderTile: function (t, n, r, i, s, o, u) { e(t).css({ "background-image": this.slider.image1.css("background-image"), "background-position": "-" + o + "px -" + u + "px" }).css3({ "transition-duration": "350ms", "transition-timing-function": "ease-in", "transition-property": "all", "transition-delay": (n + r) * this.options.delayBetweenDiagnols + "ms", "backface-visibility": "hidden" }) }, execute: function () { var t = this, n = this.slider.image1.find("div.tile"); n.last().transitionEnd(function () { t.finished() }); setTimeout(function () { n.each(function (t, n) { e(n).css({ opacity: "0" }).css3({ transform: "scale(0.8)" }) }) }, 50) } }, n)) } })(window.jQuery || window.Zepto); (function (e) { flux.transitions.concentric = function (t, n) { return new flux.transition(t, e.extend({ blockSize: 60, delay: 150, alternate: false, setup: function () { for (var t = this.slider.image1.width(), n = this.slider.image1.height(), r = Math.ceil((Math.sqrt(t * t + n * n) - this.options.blockSize) / 2 / this.options.blockSize) + 1, i = document.createDocumentFragment(), s = 0; s < r; s++) { var o = 2 * s * this.options.blockSize + this.options.blockSize; o = e("<div></div>").attr("class", "block block-" + s).css({ width: o + "px", height: o + "px", position: "absolute", top: (n - o) / 2 + "px", left: (t - o) / 2 + "px", "z-index": 100 + (r - s), "background-image": this.slider.image1.css("background-image"), "background-position": "center center" }).css3({ "border-radius": o + "px", "transition-duration": "800ms", "transition-timing-function": "linear", "transition-property": "all", "transition-delay": (r - s) * this.options.delay + "ms" }); i.appendChild(o.get(0)) } this.slider.image1.get(0).appendChild(i) }, execute: function () { var t = this, n = this.slider.image1.find("div.block"); e(n[0]).transitionEnd(function () { t.finished() }); setTimeout(function () { n.each(function (n, r) { e(r).css({ opacity: "0" }).css3({ transform: flux.browser.rotateZ((!t.options.alternate || n % 2 ? "" : "-") + "90") }) }) }, 50) } }, n)) } })(window.jQuery || window.Zepto); (function (e) { flux.transitions.warp = function (t, n) { return new flux.transitions.concentric(t, e.extend({ delay: 30, alternate: true }, n)) } })(window.jQuery || window.Zepto); (function (e) { flux.transitions.cube = function (t, n) { return new flux.transition(t, e.extend({ requires3d: true, barWidth: 100, direction: "left", perspective: 1e3, setup: function () { var t = this.slider.image1.width(), n = this.slider.image1.height(); this.slider.image1.css3({ perspective: this.options.perspective, "perspective-origin": "50% 50%" }); this.cubeContainer = e('<div class="cube"></div>').css({ width: t + "px", height: n + "px", position: "relative" }).css3({ "transition-duration": "800ms", "transition-timing-function": "linear", "transition-property": "all", "transform-style": "preserve-3d" }); t = { height: "100%", width: "100%", position: "absolute", top: "0px", left: "0px" }; this.cubeContainer.append(e('<div class="face current"></div>').css(e.extend(t, { background: this.slider.image1.css("background-image") })).css3({ "backface-visibility": "hidden" })); this.cubeContainer.append(e('<div class="face next"></div>').css(e.extend(t, { background: this.slider.image2.css("background-image") })).css3({ transform: this.options.transitionStrings.call(this, this.options.direction, "nextFace"), "backface-visibility": "hidden" })); this.slider.image1.append(this.cubeContainer) }, execute: function () { var e = this; this.slider.image1.width(); this.slider.image1.height(); this.slider.image2.hide(); this.cubeContainer.transitionEnd(function () { e.slider.image2.show(); e.finished() }); setTimeout(function () { e.cubeContainer.css3({ transform: e.options.transitionStrings.call(e, e.options.direction, "container") }) }, 50) }, transitionStrings: function (e, t) { var n = this.slider.image1.width(), r = this.slider.image1.height(); n = { up: { nextFace: flux.browser.rotateX(-90) + " " + flux.browser.translate(0, r / 2, r / 2), container: flux.browser.rotateX(90) + " " + flux.browser.translate(0, -r / 2, r / 2) }, down: { nextFace: flux.browser.rotateX(90) + " " + flux.browser.translate(0, -r / 2, r / 2), container: flux.browser.rotateX(-90) + " " + flux.browser.translate(0, r / 2, r / 2) }, left: { nextFace: flux.browser.rotateY(90) + " " + flux.browser.translate(n / 2, 0, n / 2), container: flux.browser.rotateY(-90) + " " + flux.browser.translate(-n / 2, 0, n / 2) }, right: { nextFace: flux.browser.rotateY(-90) + " " + flux.browser.translate(-n / 2, 0, n / 2), container: flux.browser.rotateY(90) + " " + flux.browser.translate(n / 2, 0, n / 2) } }; return n[e] && n[e][t] ? n[e][t] : false } }, n)) } })(window.jQuery || window.Zepto); (function (e) { flux.transitions.tiles3d = function (t, n) { return new flux.transition_grid(t, e.extend({ requires3d: true, forceSquare: true, columns: 5, perspective: 600, delayBetweenBarsX: 200, delayBetweenBarsY: 150, renderTile: function (t, n, r, i, s, o, u) { i = e("<div></div>").css({ width: i + "px", height: s + "px", position: "absolute", top: "0px", left: "0px", "background-image": this.slider.image1.css("background-image"), "background-position": "-" + o + "px -" + u + "px", "background-repeat": "no-repeat", "-moz-transform": "translateZ(1px)" }).css3({ "backface-visibility": "hidden" }); s = e(i.get(0).cloneNode(false)).css({ "background-image": this.slider.image2.css("background-image") }).css3({ transform: flux.browser.rotateY(180), "backface-visibility": "hidden" }); e(t).css({ "z-index": (n > this.options.columns / 2 ? 500 - n : 500) + (r > this.options.rows / 2 ? 500 - r : 500) }).css3({ "transition-duration": "800ms", "transition-timing-function": "ease-out", "transition-property": "all", "transition-delay": n * this.options.delayBetweenBarsX + r * this.options.delayBetweenBarsY + "ms", "transform-style": "preserve-3d" }).append(i).append(s) }, execute: function () { this.slider.image1.css3({ perspective: this.options.perspective, "perspective-origin": "50% 50%" }); var e = this, t = this.slider.image1.find("div.tile"); this.slider.image2.hide(); t.last().transitionEnd(function () { e.slider.image2.show(); e.finished() }); setTimeout(function () { t.css3({ transform: flux.browser.rotateY(180) }) }, 50) } }, n)) } })(window.jQuery || window.Zepto); (function (e) { flux.transitions.turn = function (t, n) { return new flux.transition(t, e.extend({ requires3d: true, perspective: 1300, direction: "left", setup: function () { var t = e('<div class="tab"></div>').css({ width: "50%", height: "100%", position: "absolute", top: "0px", left: this.options.direction == "left" ? "50%" : "0%", "z-index": 101 }).css3({ "transform-style": "preserve-3d", "transition-duration": "1000ms", "transition-timing-function": "ease-out", "transition-property": "all", "transform-origin": this.options.direction == "left" ? "left center" : "right center" }); e("<div></div>").appendTo(t).css({ "background-image": this.slider.image1.css("background-image"), "background-position": (this.options.direction == "left" ? "-" + this.slider.image1.width() / 2 : 0) + "px 0", width: "100%", height: "100%", position: "absolute", top: "0", left: "0", "-moz-transform": "translateZ(1px)" }).css3({ "backface-visibility": "hidden" }); e("<div></div>").appendTo(t).css({ "background-image": this.slider.image2.css("background-image"), "background-position": (this.options.direction == "left" ? 0 : "-" + this.slider.image1.width() / 2) + "px 0", width: "100%", height: "100%", position: "absolute", top: "0", left: "0" }).css3({ transform: flux.browser.rotateY(180), "backface-visibility": "hidden" }); var n = e("<div></div>").css({ position: "absolute", top: "0", left: this.options.direction == "left" ? "0" : "50%", width: "50%", height: "100%", "background-image": this.slider.image1.css("background-image"), "background-position": (this.options.direction == "left" ? 0 : "-" + this.slider.image1.width() / 2) + "px 0", "z-index": 100 }), r = e('<div class="overlay"></div>').css({ position: "absolute", top: "0", left: this.options.direction == "left" ? "50%" : "0", width: "50%", height: "100%", background: "#000", opacity: 1 }).css3({ "transition-duration": "800ms", "transition-timing-function": "linear", "transition-property": "opacity" }); this.slider.image1.append(e("<div></div>").css3({ width: "100%", height: "100%" }).css3({ perspective: this.options.perspective, "perspective-origin": "50% 50%" }).append(t).append(n).append(r)) }, execute: function () { var e = this; this.slider.image1.find("div.tab").first().transitionEnd(function () { e.finished() }); setTimeout(function () { e.slider.image1.find("div.tab").css3({ transform: flux.browser.rotateY(e.options.direction == "left" ? -179 : 179) }); e.slider.image1.find("div.overlay").css({ opacity: 0 }) }, 50) } }, n)) } })(window.jQuery || window.Zepto); (function (e) { flux.transitions.slide = function (t, n) { return new flux.transition(t, e.extend({ direction: "left", setup: function () { var t = this.slider.image1.width(), n = this.slider.image1.height(), r = e('<div class="current"></div>').css({ height: n + "px", width: t + "px", position: "absolute", top: "0px", left: "0px", background: this.slider[this.options.direction == "left" ? "image1" : "image2"].css("background-image") }).css3({ "backface-visibility": "hidden" }), i = e('<div class="next"></div>').css({ height: n + "px", width: t + "px", position: "absolute", top: "0px", left: t + "px", background: this.slider[this.options.direction == "left" ? "image2" : "image1"].css("background-image") }).css3({ "backface-visibility": "hidden" }); this.slideContainer = e('<div class="slide"></div>').css({ width: 2 * t + "px", height: n + "px", position: "relative", left: this.options.direction == "left" ? "0px" : -t + "px", "z-index": 101 }).css3({ "transition-duration": "600ms", "transition-timing-function": "ease-in", "transition-property": "all" }); this.slideContainer.append(r).append(i); this.slider.image1.append(this.slideContainer) }, execute: function () { var e = this, t = this.slider.image1.width(); if (this.options.direction == "left") t = -t; this.slideContainer.transitionEnd(function () { e.finished() }); setTimeout(function () { e.slideContainer.css3({ transform: flux.browser.translate(t) }) }, 50) } }, n)) } })(window.jQuery || window.Zepto); (function (e) { flux.transitions.swipe = function (t, n) { return new flux.transition(t, e.extend({ setup: function () { this.slider.image1.append(e("<div></div>").css({ width: "100%", height: "100%", "background-image": this.slider.image1.css("background-image") }).css3({ "transition-duration": "1600ms", "transition-timing-function": "ease-in", "transition-property": "all", "mask-image": "-webkit-linear-gradient(left, rgba(0,0,0,0) 0%, rgba(0,0,0,0) 48%, rgba(0,0,0,1) 52%, rgba(0,0,0,1) 100%)", "mask-position": "70%", "mask-size": "400%" })) }, execute: function () { var t = this, n = this.slider.image1.find("div"); e(n).transitionEnd(function () { t.finished() }); setTimeout(function () { e(n).css3({ "mask-position": "30%" }) }, 50) }, compatibilityCheck: function () { return flux.browser.supportsCSSProperty("MaskImage") } }, n)) } })(window.jQuery || window.Zepto); (function (e) { flux.transitions.dissolve = function (t, n) { return new flux.transition(t, e.extend({ setup: function () { this.slider.image1.append(e('<div class="image"></div>').css({ width: "100%", height: "100%", "background-image": this.slider.image1.css("background-image") }).css3({ "transition-duration": "600ms", "transition-timing-function": "ease-in", "transition-property": "opacity" })) }, execute: function () { var t = this, n = this.slider.image1.find("div.image"); e(n).transitionEnd(function () { t.finished() }); setTimeout(function () { e(n).css({ opacity: "0.0" }) }, 50) } }, n)) } })(window.jQuery || window.Zepto); (function (e) { e.fn.flexisel = function (t) { var n = e.extend({ visibleItems: 2, animationSpeed: 600, autoPlay: true, autoPlaySpeed: 3e3, pauseOnHover: true, setMaxWidthAndHeight: false, enableResponsiveBreakpoints: true, clone: true, responsiveBreakpoints: { portrait: { changePoint: 480, visibleItems: 1 }, landscape: { changePoint: 640, visibleItems: 2 }, tablet: { changePoint: 768, visibleItems: 3 } } }, t); var r = e(this); var i = e.extend(n, t); var s; var o = true; var u = i.visibleItems; var a = r.children().length; var f = []; var l = { init: function () { return this.each(function () { l.appendHTML(); l.setEventHandlers(); l.initializeItems() }) }, initializeItems: function () { var t = r.parent(); var n = t.height(); var o = r.children(); l.sortResponsiveObject(i.responsiveBreakpoints); var a = t.width(); s = a / u; o.width(s); if (i.clone) { o.last().insertBefore(o.first()); o.last().insertBefore(o.first()); r.css({ left: -s }) } r.fadeIn(); e(window).trigger("resize") }, appendHTML: function () { r.addClass("nbs-flexisel-ul"); r.wrap("<div class='nbs-flexisel-container'><div class='nbs-flexisel-inner'></div></div>"); r.find("li").addClass("nbs-flexisel-item"); if (i.setMaxWidthAndHeight) { var t = e(".nbs-flexisel-item img").width(); var n = e(".nbs-flexisel-item img").height(); e(".nbs-flexisel-item img").css("max-width", t); e(".nbs-flexisel-item img").css("max-height", n) } e("<div class='nbs-flexisel-nav-left'></div><div class='nbs-flexisel-nav-right'></div>").insertAfter(r); if (i.clone) { var s = r.children().clone(); r.append(s) } }, setEventHandlers: function () { var t = r.parent(); var n = r.children(); var a = t.find(e(".nbs-flexisel-nav-left")); var f = t.find(e(".nbs-flexisel-nav-right")); e(window).on("resize", function (o) { l.setResponsiveEvents(); var c = e(t).width(); var h = e(t).height(); s = c / u; n.width(s); if (i.clone) { r.css({ left: -s }) } else { r.css({ left: 0 }) } var p = a.height() / 2; var d = h / 2 - p; a.css("top", d + "px"); f.css("top", d + "px") }); e(a).on("click", function (e) { l.scrollLeft() }); e(f).on("click", function (e) { l.scrollRight() }); if (i.pauseOnHover == true) { e(".nbs-flexisel-item").on({ mouseenter: function () { o = false }, mouseleave: function () { o = true } }) } if (i.autoPlay == true) { setInterval(function () { if (o == true) l.scrollRight() }, i.autoPlaySpeed) } }, setResponsiveEvents: function () { var t = e("html").width(); if (i.enableResponsiveBreakpoints) { var n = f[f.length - 1].changePoint; for (var r in f) { if (t >= n) { u = i.visibleItems; break } else { if (t < f[r].changePoint) { u = f[r].visibleItems; break } else continue } } } }, sortResponsiveObject: function (e) { var t = []; for (var n in e) { t.push(e[n]) } t.sort(function (e, t) { return e.changePoint - t.changePoint }); f = t }, scrollLeft: function () { if (r.position().left < 0) { if (o == true) { o = false; var e = r.parent(); var t = e.width(); s = t / u; var n = r.children(); r.animate({ left: "+=" + s }, { queue: false, duration: i.animationSpeed, easing: "linear", complete: function () { if (i.clone) { n.last().insertBefore(n.first()) } l.adjustScroll(); o = true } }) } } }, scrollRight: function () { var e = r.parent(); var t = e.width(); s = t / u; var n = s - t; var f = r.position().left + (a - u) * s - t; if (n < Math.ceil(f) && !i.clone) { if (o == true) { o = false; r.animate({ left: "-=" + s }, { queue: false, duration: i.animationSpeed, easing: "linear", complete: function () { l.adjustScroll(); o = true } }) } } else if (i.clone) { if (o == true) { o = false; var c = r.children(); r.animate({ left: "-=" + s }, { queue: false, duration: i.animationSpeed, easing: "linear", complete: function () { c.first().insertAfter(c.last()); l.adjustScroll(); o = true } }) } } }, adjustScroll: function () { var e = r.parent(); var t = r.children(); var n = e.width(); s = n / u; t.width(s); if (i.clone) { r.css({ left: -s }) } } }; if (l[t]) { return l[t].apply(this, Array.prototype.slice.call(arguments, 1)) } else if (typeof t === "object" || !t) { return l.init.apply(this) } else { e.error('Method "' + method + '" does not exist in flexisel plugin!') } } })(jQuery)