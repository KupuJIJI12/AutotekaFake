export const formatDate = (date: Date | string, locale: string | string[] = "ru") : string => {
    if(typeof date === 'string'){
        return new Date(date).toLocaleString(locale, options)
    }

    return date.toLocaleString(locale, options)
}

const options = {
    year: 'numeric',
    month: 'long',
    day: 'numeric',
    hour: 'numeric',
    minute: 'numeric',
    second: 'numeric'
}

