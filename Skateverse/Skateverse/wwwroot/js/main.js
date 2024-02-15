"use strict"

/*--
    Trending
-----------------------------------*/
var swiper = new Swiper(".demo-active .swiper", {
    loop: true,
    slideVisibleClass: "swiper-slide-visible",
    // centeredSlides: true,

    // Breakpoints
    breakpoints: {
        0: {
            slidesPerView: 1,
            spaceBetween: 20,
        },
        768: {
            slidesPerView: 2,
            spaceBetween: 20,
        },
        1600: {
            slidesPerView: 2,
            spaceBetween: 30,
        },
    },
    // Pagination
    pagination: {
        el: ".demo-active .swiper-pagination",
        clickable: true,
    },
})

/*--
    On Scroll Animations
-----------------------------------*/
const scrollElements = document.querySelectorAll(".js-scroll")

const elementInView = (el, dividend = 1) => {
    const elementTop = el.getBoundingClientRect().top

    return (
        elementTop <=
        (window.innerHeight || document.documentElement.clientHeight) / dividend
    )
}

const elementOutofView = (el) => {
    const elementTop = el.getBoundingClientRect().top

    return (
        elementTop >
        (window.innerHeight || document.documentElement.clientHeight)
    )
}

const displayScrollElement = (element) => {
    element.classList.add("scrolled")
}

const hideScrollElement = (element) => {
    element.classList.remove("scrolled")
}

const handleScrollAnimation = () => {
    scrollElements.forEach((el) => {
        if (elementInView(el, 1.25)) {
            displayScrollElement(el)
        } else if (elementOutofView(el)) {
            hideScrollElement(el)
        }
    })
}

;["scroll", "load"].forEach((el) => {
    window.addEventListener(el, () => {
        handleScrollAnimation()
    })
})
