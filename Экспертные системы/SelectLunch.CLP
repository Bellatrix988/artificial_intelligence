;;; Main question


(defrule isHungry
=>
(printout t "Selection of dishes for lunch" crlf)
(printout t "Are you hungry? (yes / no)" crlf)
(assert (isHungry (read))))

(defrule gotoWork
(isHungry no)
=>
(printout t "Then get to work!") crlf)

;;; Насколько сытный обед
(defrule isFullness
(isHungry yes)
=>
(printout t "How to be a hearty lunch ( saturated / light )" crlf)
(assert (isFullness (read))))

(defrule isTime
(isFullness saturated)
=>
(printout t "You have time for cooking? ( yes / no )" crlf)
(assert (isTime (read))))


(defrule isVegetarian
(isHungry yes)
=>
(printout t "You are vegetarian ( yes / no )" crlf)
(assert (isVegetarian (read))))


;;; Vegetarian

(defrule result1
(isVegetarian yes)
(isFullness saturated)
=>
(printout t "Borsch with beans and mushrooms + chickpeas burgers + Juice" crlf))

(defrule result2
(isVegetarian yes) 
(isFullness light)
=>
(printout t "Broccoli Salad with cranberries and hazelnuts + Juice" crlf))

;;; no Vegetarian

(defrule result3
(isVegetarian no)
(isTime yes)
(isFullness saturated)
=>
(printout t "Soup with meatballs + Tomatoes a ham + Juice" crlf))

(defrule result4
(isVegetarian no) 
(isTime yes)
(isFullness light)
=>
(printout t "Salad with chicken and mushrooms + Juice" crlf))

(defrule result5
(isVegetarian no)
(isTime no)
(isFullness saturated)
=>
(printout t "Pizza with ham and cheese + tea" crlf))

(defrule result6
(isVegetarian no) 
(isTime no)
(isFullness light)
=>
(printout t "Seasonal fruits + nuts" crlf))
