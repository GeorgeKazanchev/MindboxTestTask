SELECT p.name AS product_name, c.name AS category_name
FROM public.product AS p
	LEFT JOIN public.products_categories AS pc
	ON p.id = pc.product_id
	LEFT JOIN public.category AS c
	ON c.id = pc.category_id
ORDER BY p.name;